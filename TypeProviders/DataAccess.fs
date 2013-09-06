namespace Com.Bookshelf

    module DataAccess = 

        open System
        open System.Linq
        open System.Data
        open System.Data.Linq
        open Microsoft.FSharp.Data.TypeProviders
        open Microsoft.FSharp.Linq

        type dbSchema = SqlDataConnection<"Data Source=SQLSRV\DEVSRV;Initial Catalog=Chambers.It.Bookshelf;Integrated Security=SSPI;">
                
        type Book = {
                        Id:int;
                        Name:string;
                        Author:string
                    }

        type User = {
                        Id: int;
                        Name: string;
                        Email: string
                    }
         
        type Reservation = {
            Book: Book;
            Lender: User option;
        }    
        
        let GetReservationDetails(bookId:int) : Reservation =         
                let db = dbSchema.GetDataContext()                        
                (query {
                    for row in db.Book do
                    where (row.Id = bookId)
                    select  {                                 
                                Book = {Id=bookId; Name=row.Title; Author=row.Author};
                                Lender = if row.Person = null then None
                                            else
                                            Some({Id=row.Person.Id; Name= String.concat " " [row.Person.Forename; row.Person.Surname]; Email=row.Person.Email})
                            }
                       }).FirstOrDefault()


        let GetBooks(id:int) =         
                let db = dbSchema.GetDataContext()     
                match id with
                    |0 ->                   
                        (query {
                            for row in db.Book do
                                select {
                                    Id=row.Id;
                                    Name=row.Title;
                                    Author=row.Author
                                }
                        }).ToArray()
                    |_ ->                              
                        (query {
                            for row in db.Book do                                
                                where (row.Id = id)
                                select {
                                    Id=row.Id;
                                    Name=row.Title;
                                    Author=row.Author;
                                }
                        }).ToArray()
                    
        
