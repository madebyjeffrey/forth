require test/ttester.fs

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

: 2~F  ( -- flag ) ( F: a1 a2 e1 e2 eps -- )
    4 fpick 3 fpick 2 fpick ~F >r
    3 fpick 2 fpick 2 fpick ~F
    r> and
    fdrop fdrop fdrop fdrop fdrop ;
    
T{ 1e 2e 1e 2e 0e 2~F -> true }T
T{ 1e 2e 1e 3e 0e 2~F -> false }T
    
: 3=F  ( -- flag ) ( F: a b c x y z -- )
  3 fpick 1 fpick f= >r
  4 fpick 2 fpick f= >r
  5 fpick 3 fpick f=
  r> and
  r> and
  fdrop fdrop fdrop fdrop fdrop fdrop ;
  
T{ 1e 2e 3e 1e 2e 3e 3=F -> true }
T{ 1e 2e 3e 1e 2e 4e 3=F -> false }

T{ 1e 2e 3e f3dup 1e 2e 3e 3=F -> true }T

T{ 1e 2e 3e f-rot
   3e 1e 2e 3=F
-> true }T

T{ -1e 0e 5e f-rot
   5e -1e 0e 3=F
-> true }T

T{ 1.5e 2.5e 3.5e f-rot
   3.5e 1.5e 2.5e 3=F
-> true }T

T{ 1e 2e 3e f-rot frot
   1e 2e 3e 3=F
-> true }T
    
\ x^2 - 5x + 6 = 0
\ roots: 2, 3
T{ 1e -5e 6e quadratic-real
   2e 3e 1e-10 2~F
-> true true }T

\ x^2 - 1 = 0
\ roots: -1, 1
T{ 1e 0e -1e quadratic-real
   -1e 1e 1e-10 2~F
-> true true }T

\ 2x^2 - 8x + 6 = 0
\ roots: 1, 3
T{ 2e -8e 6e quadratic-real
   1e 3e 1e-10 2~F
-> true true }T

\ x^2 + 2x + 1 = 0
\ singular/repeated root: -1
T{ 1e 2e 1e quadratic-real
   -1e -1e 1e-10 2~F
-> true true }T

\ 4x^2 - 12x + 9 = 0
\ singular/repeated root: 1.5
T{ 4e -12e 9e quadratic-real
   1.5e 1.5e 1e-10 2~F
-> true true }T