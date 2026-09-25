require fp.fs

\ ax^2 + bx + c = (-b +/- sqrt(b^2-4ac) )/ 2a
\ a != 0

: discriminant ( F: a b c -- d ) 
	frot f* 4e f* fswap fdup f* fswap f- 
	;

\ a more numerically stable quadratic solution part
\ q = -1/2 [ b + sgn(b)*discriminant ]
: fq ( F: a b c -- q )
	3fdup discriminant fsqrt  ( F: a b c sqrt[d] )
	fnip frot fdrop fswap     ( F: d b )
	fdup fsgn                 ( F: d b sgn[b] )
	frot f* f+ -0.5e f*
	;
  
\ when b = 0 - still have issues and discriminant is 0  
: quadratic-real
	( -- true ) ( F: a b c -- x1 x2 ) 
	3fdup fq          ( F: a b c q )
	fdup f-rot f/     ( F: a b q c/q ) 
	frot fdrop f-rot  ( F: c/q a q )
	fswap f/ fswap    ( F: a/q c/q )	
	true 
	;
	
: quadratic-complex
	( -- false ) ( F: a b c -- 0e 0e )
	fdrop fdrop fdrop 0e 0e false ;

: quadratic 
	( -- true ) ( F: a b c -- x1 x2 ) \ disc >= 0
	( -- false ) ( F: a b c -- 0e 0e ) \ disc < 0
	3fdup discriminant 0e f>= 
	if 
		quadratic-real 
	else
		quadratic-complex
	then 
	;

