CREATE TABLE Produtos(
    idProduto INT PRIMARY KEY NOT NULL,
    descricao VARCHAR(100) NOT NULL,
    precoUnitario DECIMAL(9,2) NOT NULL,
    saldoEstoque INT
);

CREATE TABLE Vendas(
    idVenda INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    nomeCliente VARCHAR(100) NOT NULL,
    valorTotal DECIMAL(12,2) NOT NULL,
    dataVenda DATETIME DEFAULT CURRENT_TIMESTAMP
);

 
CREATE TABLE ItensVenda (
    idItensVenda INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    idProduto INT NOT NULL, 
    idVenda INT NOT NULL,  
    quantidade INT NOT NULL,
    valorTotalItem DECIMAL(12,2) NOT NULL,
    precoUnitario DECIMAL(9,2) NOT NULL,
    CONSTRAINT FK_ItensVenda_Produtos FOREIGN KEY (idProduto) REFERENCES Produtos(idProduto),
    CONSTRAINT FK_ItensVenda_Vendas FOREIGN KEY (idVenda) REFERENCES Vendas(idVenda)
);