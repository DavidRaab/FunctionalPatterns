#!/usr/bin/env -S dotnet fsi

// I would do the same; Nothing to change.

let benchmark task =
    printfn "Starting Task"

    let sw = System.Diagnostics.Stopwatch.StartNew ()
    task ()
    sw.Stop ()

    printfn "Task Ended Time: %f seconds." (sw.Elapsed.TotalSeconds)

let doSomething (timeout:int) =
    printfn "Task Start..."
    System.Threading.Thread.Sleep timeout
    printfn "Waiting..."
    System.Threading.Thread.Sleep timeout
    printfn "Still Waiting..."
    System.Threading.Thread.Sleep timeout
    printfn "Task End..."

benchmark (fun _ -> doSomething 100)
benchmark (fun _ -> doSomething 500)
benchmark (fun _ -> doSomething 1000)

// Outpput:
//
// Starting Task
// Task Start...
// Waiting...
// Still Waiting...
// Task End...
// Task Ended Time: 0.300626 seconds.
// Starting Task
// Task Start...
// Waiting...
// Still Waiting...
// Task End...
// Task Ended Time: 1.500488 seconds.
// Starting Task
// Task Start...
// Waiting...
// Still Waiting...
// Task End...
// Task Ended Time: 3.000574 seconds.