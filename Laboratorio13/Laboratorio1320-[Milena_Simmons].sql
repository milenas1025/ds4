Select  ProductName, CompanyName, ContactName
From Products P
FULL JOIN Suppliers S
ON P.SupplierID=S.SupplierID