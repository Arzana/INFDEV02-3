﻿open Compile

[<EntryPoint>]
let main argv = 
  do batchProcess Chapter1.Week1_2.slides "INFDEV02_3_Lec1_OO_intro" "The INFDEV team" "Introduction" true false
  do batchProcess Chapter1.Week3.slides "INFDEV02_3_Lec2_Static_typing" "The INFDEV team" "Type systems" true false
  //do batchProcess StateTraceSamples.slides "test" "The INFDEV team" "test" true false
  0
