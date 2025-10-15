Select OrderID, P.ProductID, ProductName
From Products P
INNER JOIN [Order Details] OD
ON P.ProductID=OD.ProductID
