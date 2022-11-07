 Вопрос 2
 * В базе данных MS SQL Server есть продукты и категории.
 * Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов.
 * Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории».
 * Если у продукта нет категорий, то его имя все равно должно выводиться.
 
 
CREATE TABLE Products (
  Id INT PRIMARY KEY,
  "Name" TEXT
);

INSERT INTO Products
VALUES
  (1, 'Джоггеры из френч терри'),
  (2, 'Шапка вязаная'),
  (3, 'Платье А-силуэта из шифона');

CREATE TABLE Categories (
  Id INT PRIMARY KEY,
  "Name" TEXT
);

INSERT INTO Categories
VALUES
  (1, 'Штаны'),
  (2, 'Шапка'),
  (3, 'Джоггеры');

CREATE TABLE ProductCategories (
  ProductId INT FOREIGN KEY REFERENCES Products(Id),
  CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
  PRIMARY KEY (ProductId, CategoryId)
);

INSERT INTO ProductCategories
VALUES
  (1, 1),
  (1, 3),
  (2, 2);

SELECT P."Name", C."Name"
FROM Products P
LEFT JOIN ProductCategories Pc
  ON P.Id = Pc.ProductId
LEFT JOIN Categories C
  ON Pc.CategoryId = C.Id;
