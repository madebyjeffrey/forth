require test/ttester.fs

include fp.fs

T{ 1e 2e 2fdrop -> }T
T{ 1e 2e 3e 2fdrop 1e 0e f~ -> true }T    
    
T{ 1e 2e 1e 2e 0e 2F~ -> true }T
T{ 1e 2e 1e 3e 0e 2F~ -> false }T
      
T{ 1e 2e 3e 1e 2e 3e 3f= -> true }T
T{ 1e 2e 3e 1e 2e 4e 3f= -> false }T

T{ 1e 2e 3e 3fdup 3F= -> true }T

T{ 1e 2e 3e f-rot
   3e 1e 2e 3f=
-> true }T

T{ -1e 0e 5e f-rot
   5e -1e 0e 3f=
-> true }T

T{ 1.5e 2.5e 3.5e f-rot
   3.5e 1.5e 2.5e 3f=
-> true }T

T{ 1e 2e 3e f-rot frot
   1e 2e 3e 3f=
-> true }T
