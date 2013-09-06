namespace WebService

    module Services = 
        open Com.Bookshelf.DataAccess
        open RequestObjects
        open ServiceStack.Service
        open ServiceStack.ServiceHost
        open ServiceStack.WebHost.Endpoints
        open ServiceStack.ServiceInterface

        type BookService() =
            inherit Service()
            member x.Get (request:Book) = GetBooks(request.Id)
  
        type ReservationService() =
            inherit Service()
            member x.Get (request:Reservation) = GetReservationDetails(request.Id)