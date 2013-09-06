
// NOTE: If warnings appear, you may need to retarget this project to .NET 4.0. Show the Solution
// Pad, right-click on the project node, choose 'Options --> Build --> General' and change the target
// framework to .NET 4.0 or .NET 4.5.
namespace WebService
    module Main = 
        open System
        open Com.Bookshelf.DataAccess
        open ServiceStack.Service
        open ServiceStack.ServiceHost
        open ServiceStack.WebHost.Endpoints
        open ServiceStack.ServiceInterface
        open Services

        type AppHost() =
            inherit AppHostHttpListenerBase("Bookshelf Services", typeof<BookService>.Assembly)
            override this.Configure container = ignore()

        //Run it!
        [<EntryPoint>]
        let main args =

            let host = if args.Length = 0 then "http://*:8080/" else args.[0]
            printfn "listening on %s ..." host
            let appHost = new AppHost()
            appHost.Init()
            appHost.Start host
            Console.ReadLine() |> ignore
            0
