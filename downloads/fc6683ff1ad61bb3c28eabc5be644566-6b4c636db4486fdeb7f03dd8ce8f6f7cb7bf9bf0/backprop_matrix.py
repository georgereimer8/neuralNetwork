def relu_prime(self, Z):
  '''
  Z - weighted input matrix

  Returns the gradient of the 
  Z matrix where all negative 
  values are switched to 0 and
  all positive values switched to 1
  '''
  Z[Z < 0] = 0
  Z[Z > 0] = 1
  return Z

def cost(self, output, y):
  cost = np.sum((output - y)**2) / 2.0
  return cost

def cost_prime(self, output, y):
  return output - y

def backprop(self, X, y, lr):
  '''
  X - input matrix from training set
  y - expected output matrix
  lr - learning rate
  '''
  ### Feed Forward ###

  # Hidden layer
  Zh = np.dot(X, self.Wh) + self.Bh
  H = self.relu(Zh)

  # Output layer
  Zo = np.dot(H, self.Wo) + self.Bo
  out = self.relu(Zo)

  #### Backprop ####

  # Layer Error
  Eo = (out - y) * self.relu_prime(Zo)
  Eh = np.dot(Eo, self.Wo.T) * self.relu_prime(Zh)

  # Cost derivative for weights
  dWo = np.dot(H.T, Eo)
  dWh = np.dot(X.T, Eh)

  # Cost derivative for bias
  dBo = np.sum(Eo, axis=0, keepdims=True)
  dBh = np.sum(Eh, axis=0, keepdims=True)

  # Update weights
  self.Wo -= lr * dWo
  self.Wh -= lr * dWh

  # Update biases
  self.Bo -= lr * dBo
  self.Bh -= lr * dBh