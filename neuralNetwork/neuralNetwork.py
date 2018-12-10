"""
network.py
~~~~~~~~~~
A module to implement the stochastic gradient descent learning
algorithm for a feedforward neural network.  Gradients are calculated
using backpropagation.  Note that I have focused on making the code
simple, easily readable, and easily modifiable.  It is not optimized,
and omits many desirable features.
"""

#### Libraries
# Standard library
import random

# Third-party libraries
import numpy as np

class Network(object):

    Shuffle = 0
    ZeroStart = 0
    Verbose = 0

    def __init__(self, sizes):
        """The list ``sizes`` contains the number of neurons in the
        respective layers of the network.  For example, if the list
        was [2, 3, 1] then it would be a three-layer network, with the
        first layer containing 2 neurons, the second layer 3 neurons,
        and the third layer 1 neuron.  The biases and weights for the
        network are initialized randomly, using a Gaussian
        distribution with mean 0, and variance 1.  Note that the first
        layer is assumed to be an input layer, and by convention we
        won't set any biases for those neurons, since biases are only
        ever used in computing the outputs from later layers."""
        self.num_layers = len(sizes)
        self.sizes = sizes
        self.biases = [np.random.randn(y, 1) for y in sizes[1:]]
        self.weights = [np.random.randn(y, x)
                        for x, y in zip(sizes[:-1], sizes[1:])]

        # the 0.0 initialization values and no mini bach shuffle produce: 
        # epoch 0 3298
        # epoch 1 3247
        # epoch 2 3207
        # epoch 3 3197
        # epoch 4 3259  etc

        # zero start 
        if self.ZeroStart == 1:
            self.biases = [np.full((y,1),0.0) for y in sizes[1:]]
            self.weights = [np.full((y,x),0.0) for x,y in zip(sizes[:-1], sizes[1:])]
            self.num_layers = len(sizes)

    def feedforward(self, a):
        """Return the output of the network if ``a`` is input."""
        result = a
        for b, w in zip(self.biases, self.weights):
            result = sigmoid(np.dot(w, result)+b)
        return result

    def update_mini_batch(self, mini_batch, eta):
        """Update the network's weights and biases by applying
        gradient descent using backpropagation to a single mini batch.
        The ``mini_batch`` is a list of tuples ``(x, y)``, and ``eta``
        is the learning rate."""
        self.nabla_b = [np.zeros(b.shape) for b in self.biases]
        self.nabla_w = [np.zeros(w.shape) for w in self.weights]
        for x, y in mini_batch:
            self.delta_nabla_b, self.delta_nabla_w = self.backprop(x, y)
            self.nabla_b = [nb+dnb for nb, dnb in zip(self.nabla_b, self.delta_nabla_b)]
            self.nabla_w = [nw+dnw for nw, dnw in zip(self.nabla_w, self.delta_nabla_w)]
            #self.printActivations(-1, self.sampleCount)
            self.sampleCount += 1

        """ 
        for b, nb in zip(self.biases, nabla_b):
            eta1 = eta / len(mini_batch)
            a1 = eta1 * nb
            a2 = b - a1
            a3 = 0 """

        self.biases = [b-(eta/len(mini_batch))*nb
                       for b, nb in zip(self.biases, self.nabla_b)]

        self.weights = [w-(eta/len(mini_batch))*nw
                        for w, nw in zip(self.weights, self.nabla_w)]

        if self.Verbose == 9:
            self.printLayer( -1 )

        wait = 0


    def SGD(self, training_data, epochs, mini_batch_size, eta,
            test_data=None):
        """Train the neural network using mini-batch stochastic
        gradient descent.  The ``training_data`` is a list of tuples
        ``(x, y)`` representing the training inputs and the desired
        outputs.  The other non-optional parameters are
        self-explanatory.  If ``test_data`` is provided then the
        network will be evaluated against the test data after each
        epoch, and partial progress printed out.  This is useful for
        tracking progress, but slows things down substantially."""

        print("Starting Network Alpha")

        if test_data: 
            test_data = list(test_data) 
            n_test = len(test_data)

        self.sampleCount = 0
        runTests = 1
        training_data = list(training_data)
        n = len(training_data)
        batchIndex = 0
        for j in range(epochs):
            # keep deterministic while debugging so don't shuffle yet
            if self.Shuffle == 1:
                random.shuffle(training_data) 
            mini_batches = [
                training_data[k:k+mini_batch_size]
                for k in range(0, n, mini_batch_size)]
            for mini_batch in mini_batches:
                self.update_mini_batch(mini_batch, eta)
                if self.Verbose == 9:
                    self.printActivations(-1, batchIndex)
                batchIndex += 1
                wait = 0
            if runTests == 1:
                if test_data:
                    # self.printActivations(-1, j)
                    print ("Epoch {0}: {1} / {2}".format( j, self.evaluate(test_data), n_test))
                else:
                    print ("Epoch {0} complete".format(j))

        print ("Epoch {0}: {1} / {2}".format( j, self.evaluate(test_data), n_test))
        
    def backprop(self, x, y):
        """Return a tuple ``(nabla_b, nabla_w)`` representing the
        gradient for the cost function C_x.  ``nabla_b`` and
        ``nabla_w`` are layer-by-layer lists of numpy arrays, similar
        to ``self.biases`` and ``self.weights``."""
        input = -3 
        hidden = -2 
        output = -1 

        self.delta_nabla_b = [np.zeros(b.shape) for b in self.biases]
        self.delta_nabla_w = [np.zeros(w.shape) for w in self.weights]
        # feedforward
        activation = x
        self.activations = [x] # list to store all the activations, layer by layer
        zs = [] # list to store all the z vectors, layer by layer
        for b, w in zip(self.biases, self.weights):
            z = np.dot(w, activation)+b
            zs.append(z)
            activation = sigmoid(z)
            self.activations.append(activation)

        # backward pass
        outputError = self.cost_derivative(self.activations[output], y) * sigmoid_prime(zs[output])
        self.delta_nabla_b[output] = outputError
        self.delta_nabla_w[output] = np.dot(outputError, self.activations[hidden].transpose())

        # Note that the variable l in the loop below is used a little
        # differently to the notation in Chapter 2 of the book.  Here,
        # l = 1 means the last layer of neurons, l = 2 is the
        # second-last layer, and so on.  It's a renumbering of the
        # scheme in the book, used here to take advantage of the fact
           # that Python can use negative indices in lists.
        #for l in range(2, self.num_layers):
        #z = zs[hidden]
        #sp = sigmoid_prime(zs[hidden])

        hiddenError = np.dot(self.weights[output].transpose(), outputError) * sigmoid_prime(zs[hidden])
        self.delta_nabla_b[hidden] = hiddenError
        self.delta_nabla_w[hidden] = np.dot(hiddenError, self.activations[input].transpose())

        return (self.delta_nabla_b, self.delta_nabla_w)

    def evaluate(self, test_data):
        """Return the number of test inputs for which the neural
        network outputs the correct result. Note that the neural
        network's output is assumed to be the index of whichever
        neuron in the final layer has the highest activation."""
        test_results = [(np.argmax(self.feedforward(x)), y)
                        for (x, y) in test_data]
        result = sum(int(x == y) for (x, y) in test_results)
        return result

    def cost_derivative(self, output_activations, y):
        """Return the vector of partial derivatives \partial C_x /
        \partial a for the output activations."""
        return (output_activations-y)

    def printActivations( self, layer, sample ):
        Name = self.getLayerName(layer) 
        s = "{0},".format(sample)
        for a in self.activations[layer]:
            s += "{0},".format(a)
        s += "\n"
        for char in '[]':
            s = s.replace(char,'')
        print(s)
        
    def printLayer(self, layer ):
        Name = self.getLayerName(layer) 
        s = "Layer({0}) -----------\n".format( Name)
        s += "           Activations:{0}\n".format(self.activations[layer])
        s += "                Biases:{0}\n".format(self.biases[layer])
        s += "               Weights:{0}\n".format(self.weights[layer])
        s += "        GradientBiases:{0}\n".format(self.nabla_b[layer])
        s += "       GradientWeights:{0}\n".format(self.nabla_w[layer])
        s += "   deltaGradientBiases:{0}\n".format(self.delta_nabla_b[layer])
        s += "  deltaGradientWeights:{0}\n".format(self.delta_nabla_w[layer])
        print( s )

    def getLayerName( self, layer ):
        name = "Input"
        if( layer == - 2 ):
           name = "Hidden" 
        else:
            if( layer == -1 ):
                name = "Output"
        return name

#### Miscellaneous functions
def sigmoid(z):
    """The sigmoid function."""
    return 1.0/(1.0+np.exp(-z))

def sigmoid_prime(z):
    """Derivative of the sigmoid function."""
    return sigmoid(z)*(1-sigmoid(z))
