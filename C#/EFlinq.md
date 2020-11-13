
```
var query = from c in Customers
where c.Country == "UK" &&
      c.City == "London"
select c);
To
SELECT ... FROM Customers AS c WHERE c.Country = "UK" AND c.City = "London"
```
query.ToSqlStatementString()
解决方法
```
CustomDataContext dc = new CustomDataContext();
IQueryable<Customer> query =
  from c in dc.Customer
  where c.Country == "UK"
  select c;
//
string command = dc.GetCommand(query).CommandText;
```
