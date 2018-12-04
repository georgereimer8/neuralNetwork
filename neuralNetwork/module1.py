
import neuralNetwork
from neuralNetwork import Network
import originalNetwork
from originalNetwork import Network
import mnist_loader


def main():
    print ("Loading test data")
    training_data, validation_data, test_data = mnist_loader.load_data_wrapper()
    
    net = neuralNetwork.Network([784,30,10])
    #net = originalNetwork.Network([784,30,10])
    net.SGD(training_data, 30, 10, 3.0, test_data=test_data)


if __name__ == "__main__":
    main()