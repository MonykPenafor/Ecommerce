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

 
CREATE TABLE ItensVendas (
    idItemVenda INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    idProduto INT NOT NULL, 
    idVenda INT NOT NULL,  
    quantidade INT NOT NULL,
    valorTotalItem DECIMAL(12,2) NOT NULL,
    precoUnitario DECIMAL(9,2) NOT NULL,
    CONSTRAINT FK_ItensVenda_Produtos FOREIGN KEY (idProduto) REFERENCES Produtos(idProduto),
    CONSTRAINT FK_ItensVenda_Vendas FOREIGN KEY (idVenda) REFERENCES Vendas(idVenda)
);


CREATE PROCEDURE GetVendaDetalhada
    @idVenda INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        v.idVenda,
        iv.idItemVenda,
        iv.quantidade,
        iv.precoUnitario,
        iv.valorTotalItem,
        p.descricao,
		p.idProduto
    FROM 
        Vendas v
    INNER JOIN 
        ItensVendas iv ON v.idVenda = iv.idVenda
    INNER JOIN 
        Produtos p ON iv.idProduto = p.idProduto
    WHERE 
        v.idVenda = @idVenda;
END;


EXEC GetVendaDetalhada @idVenda = 4; 


CREATE TRIGGER trg_AjustarEstoque
ON ItensVendas
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Produtos
    SET saldoEstoque = saldoEstoque - i.quantidade
    FROM Produtos p
    INNER JOIN Inserted i ON p.idProduto = i.idProduto
END;
