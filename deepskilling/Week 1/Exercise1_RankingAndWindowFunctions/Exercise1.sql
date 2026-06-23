USE CognizantAdvancedSQL;
GO

SELECT
    ProductID,
    ProductName,
    Category,
    Price,

    ROW_NUMBER() OVER
    (
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS RowNum,

    RANK() OVER
    (
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS RankNum,

    DENSE_RANK() OVER
    (
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS DenseRankNum

FROM Products;

WITH ProductRanking AS
(
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,

        ROW_NUMBER() OVER
        (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS RowNum,

        RANK() OVER
        (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS RankNum,

        DENSE_RANK() OVER
        (
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS DenseRankNum

    FROM Products
)

SELECT *
FROM ProductRanking
WHERE RowNum <= 3;