namespace WebService

    module RequestObjects =
        open ResponseObjects
        open Com.Bookshelf.DataAccess
        open ServiceStack.Service
        open ServiceStack.ServiceHost       

        [<Route("/book")>]
        [<Route("/book/{id}")>]
        type Book() =
            interface IReturn<BookResponse> 
            member val Id : int = 0 with get, set
        

        [<Route("/reservation/{id}")>]
        type Reservation() =
            interface IReturn<ReservationResponse> 
            member val Id : int = 0 with get, set