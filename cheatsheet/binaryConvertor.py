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
    Wh = np.random.randn(INPUT_LAYER_SIZE, HIDDEN_LAYER_SIZE) * np.sqrt(2.0/INPUT_LAYER_SIZE)
    Wo = np.random.randn(HIDDEN_LAYER_SIZE, OUTPUT_LAYER_SIZE) * np.sqrt(2.0/HIDDEN_LAYER_SIZE)

def initBias():
    global Bh,Bo
    Bh = np.full((1, HIDDEN_LAYER_SIZE), 0.1)
    Bo = np.full((1, OUTPUT_LAYER_SIZE), 0.1)

def initInput( value):
    global X,Y
    X = [0] * 10
    X[value] = 1 

    Y = [0] * 10

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
    Eh = (Eo * Wo ) * sigmoid_prime(Zh)

    # Cost derivative for weights
    dWo = Eo * H
    dWh = Eh * x

    # Update weights
    Wh -= lr * dWh
    Wo -= lr * dWo

def main():
    initWeights()
    initInput(3)
    initBias()

    feedForward()
    backprop()

if __name__ == "__main__":
    main()