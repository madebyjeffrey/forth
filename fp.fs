
: 2fdrop ( F: r1 r2 -- )
	fdrop fdrop ;

: 2fdup ( F: r1 r2 -- r1 r2 r1 r2 ) 
	fover fover ;

: 3fdup  ( F: a b c -- a b c a b c )
  2 fpick 2 fpick 2 fpick ;
  
: f-rot  ( F: r1 r2 r3 -- r3 r1 r2 )
  frot frot ;

: 2f~  ( -- flag ) ( F: a1 a2 e1 e2 eps -- )
    4 fpick 3 fpick 2 fpick f~ >r
    3 fpick 2 fpick 2 fpick f~
    r> and
    fdrop fdrop fdrop fdrop fdrop ;

: 3f=  ( -- flag ) ( F: a b c x y z -- )
  3 fpick 1 fpick f= >r
  4 fpick 2 fpick f= >r
  5 fpick 3 fpick f=
  r> and
  r> and
  fdrop fdrop fdrop fdrop fdrop fdrop ;

: fsgn ( r1 -- r2 ) \ floating-point sign function
  fdup f0< if
    fdrop -1.0e0
  else
    f0> if 1.0e0 else 0.0e0 then
  then ;