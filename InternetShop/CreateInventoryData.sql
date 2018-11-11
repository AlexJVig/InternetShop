insert into Inventory(ProductID, BranchID, Quantity)
select ProductID, 5, ABS(RANDOM() % 100)
from Inventory
where InventoryID < 21