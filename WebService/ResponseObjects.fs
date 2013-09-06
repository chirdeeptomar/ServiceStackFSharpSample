namespace WebService

    module ResponseObjects = 
        open Com.Bookshelf.DataAccess
        open ServiceStack.Service

        type BookResponse = 
                {
                    ResponseStatus : IResponseStatus;
                    Result : Book[]
                }    
                
        type ReservationResponse = 
                {
                    ResponseStatus : IResponseStatus;
                    Reservation : Reservation;                    
                }