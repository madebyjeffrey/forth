require test/ttester.fs
require fp.fs

include quadratic.fs

T{ 1e 0e 1e discriminant -4e 1e-12 f~ -> true }T
T{ 1e 2e 2e discriminant -4e 1e-12 f~ -> true }T
T{ 2e 3e 2e discriminant -7e 1e-12 f~ -> true }T
T{ 1e 2e 1e discriminant 0e 1e-12 f~ -> true }T
T{ 4e 4e 1e discriminant 0e 1e-12 f~ -> true }T
T{ 1e 0e 0e discriminant 0e 1e-12 f~ -> true }T
T{ 1e 0e -1e discriminant 4e 1e-12 f~ -> true }T
T{ 1e 5e 6e discriminant 1e 1e-12 f~ -> true }T
T{ 2e 5e 2e discriminant 9e 1e-12 f~ -> true  }T
T{ 1e -5e 6e discriminant 1e 1e-12 f~ -> true  }T
T{ -1e 0e 1e discriminant 4e 1e-12 f~ -> true }T
T{ -2e 3e 2e discriminant 25e 1e-12 f~ -> true  }T
    
\ x^2 - 5x + 6 = 0
\ roots: 2, 3
T{ 1e -5e 6e quadratic-real
   2e 3e 1e-10 2f~
-> true true }T

\ x^2 - 1 = 0
\ roots: -1, 1
T{ 1e 0e -1e quadratic-real
   -1e 1e 1e-10 2f~
-> true true }T

\ 2x^2 - 8x + 6 = 0
\ roots: 1, 3
T{ 2e -8e 6e quadratic-real
   1e 3e 1e-10 2f~
-> true true }T

\ x^2 + 2x + 1 = 0
\ singular/repeated root: -1
T{ 1e 2e 1e quadratic-real
   -1e -1e 1e-10 2f~
-> true true }T

\ 4x^2 - 12x + 9 = 0
\ singular/repeated root: 1.5
T{ 4e -12e 9e quadratic-real
   1.5e 1.5e 1e-10 2f~
-> true true }T

\ x^2 + 1 = 0
\ discriminant = -4
T{ 1e 0e 1e quadratic 2fdrop -> false }T

\ x^2 + 2x + 5 = 0
\ discriminant = 4 - 20 = -16
T{ 1e 2e 5e quadratic 2fdrop  -> false }T

\ 2x^2 + 4x + 10 = 0
\ discriminant = 16 - 80 = -64
T{ 2e 4e 10e quadratic 2fdrop  -> false }T

\ 3x^2 - 6x + 10 = 0
\ discriminant = 36 - 120 = -84
T{ 3e -6e 10e quadratic 2fdrop  -> false }T

\ x^2 - 2x + 10 = 0
\ discriminant = 4 - 40 = -36
T{ 1e -2e 10e quadratic 2fdrop -> false }T