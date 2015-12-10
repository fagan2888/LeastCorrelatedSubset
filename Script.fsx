﻿
#load @"Binomial.fs"
#load @"LeastCorrelated.fs"
#r @"packages\Alea.CUDA.2.2.0.3307\lib\net40\Alea.CUDA.dll"

open Alea.CUDA

open Binomial
open LeastCorrelated

let A = 
    [|
        [| 1.0000; 0.9419; 0.5902; 0.6354; 0.3949; 0.2484; 0.6761; 0.7566; 0.3165; 0.0683 |]
        [| 0.9419; 1.0000; 0.0321; 0.0286; 0.3434; 0.6117; 0.2296; 0.2289; 0.7477; 0.0486 |]
        [| 0.5902; 0.0321; 1.0000; 0.2492; 0.6890; 0.5896; 0.4554; 0.7329; 0.5267; 0.4777 |]
        [| 0.6354; 0.0286; 0.2492; 1.0000; 0.7157; 0.1464; 0.6292; 0.2192; 0.4948; 0.7013 |]
        [| 0.3949; 0.3434; 0.6890; 0.7157; 1.0000; 0.1071; 0.8018; 0.8363; 0.8255; 0.8406 |]
        [| 0.2484; 0.6117; 0.5896; 0.1464; 0.1071; 1.0000; 0.8634; 0.3150; 0.2573; 0.1169 |]
        [| 0.6761; 0.2296; 0.4554; 0.6292; 0.8018; 0.8634; 1.0000; 0.1769; 0.6815; 0.5119 |]
        [| 0.7566; 0.2289; 0.7329; 0.2192; 0.8363; 0.3150; 0.1769; 1.0000; 0.6784; 0.4225 |]
        [| 0.3165; 0.7477; 0.5267; 0.4948; 0.8255; 0.2573; 0.6815; 0.6784; 1.0000; 0.0107 |]
        [| 0.0683; 0.0486; 0.4777; 0.7013; 0.8406; 0.1169; 0.5119; 0.4225; 0.0107; 1.0000 |]
    |]

let A' = lowerTriangularPacked A
let A1 = unpack 10 A'

let sel = [|0; 1; 4; 9|]
let Asub = Cpu.subMatixPacked A' sel
let Asub1 = unpack 4 Asub

let best = Cpu.leastCorrelated A' 10 5
let cor = Cpu.subMatixPacked A' best |> unpack 5

