import numpy as np

INPUT_LAYER_SIZE = 10
HIDDEN_LAYER_SIZE = 4
OUTPUT_LAYER_SIZE = 10

Zh = []
Zo = []
Wh = []
Wo = []
Bh = []
Bo = []
X = []
Y = []
H = []
yHat = []
lr = 0.1


def sigmoid(z):
    """The sigmoid function."""
    return 1.0/(1.0+np.exp(-z))

def sigmoid_prime(z):
    """Derivative of the sigmoid function."""
    return sigmoid(z)*(1-sigmoid(z))

def initWeights():
    global Wh,Wo
    Wh = np.full((INPUT_LAYER_SIZE, HIDDEN_LAYER_SIZE),1.0) 
    Wo = np.full((HIDDEN_LAYER_SIZE, OUTPUT_LAYER_SIZE),1.0) 

def initBias():
    global Bh,Bo
    Bh = np.full((1, HIDDEN_LAYER_SIZE), 0.5)
    Bo = np.full((1, OUTPUT_LAYER_SIZE), 0.5)

def initInput( value):
    global X,Y
    '''
    TODO: convert value to binary and put it into X
    ONLY value=zero works for now
    '''
    X = [0] * 10

    Y = [0] * 10
    Y[value] = 1 

'''
X    - input matrix
Zh   - hidden layer weighted input
Zo   - output layer weighted input
H    - hidden layer activation
y    - supervised output layer (lables)
yHat - output layer predictions
'''
def feedForward():
    global H,Wh,Wo,Bh,Bo,Zh,Zo,yHat,X

    # Hidden layer
    Zh = np.dot(X, Wh) + Bh
    H = sigmoid(Zh)

    # Output layer
    Zo = np.dot(H, Wo) + Bo
    yHat = sigmoid(Zo)

def backprop():
    global H,Wh,Wo,Bh,Bo,Zh,Zo,yHat,X,Y,lr
    # Layer Error
    Eo = (yHat - Y) * sigmoid_prime(Zo)
    a = Eo * Wo
    b = sigmoid_prime(Zh)
    c = sigmoid_prime(Zo)
    d = np.dot(a,b) 
    e = a * b
    Eh = (Eo * Wo ) * sigmoid_prime(Zh)

    # Cost derivative for weights
    dWo = Eo * H
    dWh = Eh * X

    # Update weights
    Wh -= lr * dWh
    Wo -= lr * dWo

def relu_prime(Z):
    '''
    Z - weighted input matrix

    Returns gradient of Z where all
    negative values are set to 0 and
    all positive values set to 1
    '''
    Z[Z < 0] = 0
    Z[Z > 0] = 1
    return Z

def main():
    initWeights()
    initInput(0)
    initBias()

    feedForward()
    backprop()

if __name__ == "__main__":
    main()