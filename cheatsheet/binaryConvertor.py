import numpy as np
import os
import sys

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
lr = 1.0


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
    X = [0] * 10

    Y = [0] * 10
    Y[value] = 1 

    '''
    binary = { 
        0:[0,0,0,0,0,0,0,0,0,0],
        1:[0,0,0,0,0,0,0,0,0,1],
        2:[0,0,0,0,0,0,0,0,1,0],
        3:[0,0,0,0,0,0,0,0,1,1],
        4:[0,0,0,0,0,0,0,1,0,0],
        5:[0,0,0,0,0,0,0,1,0,1],
        6:[0,0,0,0,0,0,0,1,1,0],
        7:[0,0,0,0,0,0,0,1,1,1],
        8:[0,0,0,0,0,0,1,0,0,0],
        9:[0,0,0,0,0,0,1,0,0,1]
        }
    decimal = { 
        0:[0,0,0,0,0,0,0,0,0,1],
        1:[0,0,0,0,0,0,0,0,1,0],
        2:[0,0,0,0,0,0,0,1,0,0],
        3:[0,0,0,0,0,0,1,0,0,0],
        4:[0,0,0,0,0,1,0,0,0,0],
        5:[0,0,0,0,1,0,0,0,0,0],
        6:[0,0,0,1,0,0,0,0,0,0],
        7:[0,0,1,0,0,0,0,0,0,0],
        8:[0,1,0,0,0,0,0,0,0,0],
        9:[1,0,0,0,0,0,0,0,0,0]
        }

    X = np.full((1,10),0)
    Y = np.full((1,10),0)

    ''' training data '''
    X[0] = binary[value] 
    Y[0] = decimal[ value ]

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
    Eh = np.dot(Eo,Wo.transpose() ) * sigmoid_prime(Zh)

    # Cost derivative for weights
    dWo = np.dot( H.transpose(), Eo )
    dWh = np.dot( X.transpose(), Eh)
    
    # Update weights
    Wh -= lr * dWh
    Wo -= lr * dWo
      # Cost derivative for bias

    dBo = np.sum(Eo, axis=0, keepdims=True)
    dBh = np.sum(Eh, axis=0, keepdims=True)

    # Update biases
    Bo -= lr * dBo
    Bh -= lr * dBh

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

def prediction():
    print("\nPrediction:")
    for i in range(10):
        if yHat[0,i] > 0.99:
            print(str(9-i) + ",", end ="")
    print()

def main():
    os.system("mode con cols=250 lines=50")

    lr = 2.0

    initWeights()
    initInput(5)
    initBias()

    for i in range(1,10000):
        feedForward()
        backprop()
        

        b = str(yHat)        
        c = b.replace('\n','')
        print(str(i)+' '+c,end='\r')

    print()
    prediction()




if __name__ == "__main__":
    main()