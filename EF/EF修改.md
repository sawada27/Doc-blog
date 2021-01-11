```
using (var context = new DatabaseContext())
    {       
       using (IDbContextTransaction transaction = context.Database.BeginTransaction())
       {

         string sqlQuery = "select * from 表名 where id =1 for update";
         var info = context.表名.FromSql(sqlQuery).FirstOrDefault();                   
               //TODO           
               transaction.Commit(); 
       }
    }
```

