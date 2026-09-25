require fp.fs

\ ax^2 + bx + c = (-b +/- sqrt(b^2-4ac) )/ 2a
\ a != 0

: discriminant ( F: a b c -- d ) 
	frot f* 4e f* fswap fdup f* fswap f- 
	;
  
: quadratic-real
	( -- true ) ( F: a b c -- x1 x2 ) 
	3fdup discriminant fsqrt ( F: a b c sqrt-d )
	frot fnegate 	( F: a c sqrt-d -b )
	frot fdrop 		( F: a sqrt-d -b )
	2fdup 			( F: a sqrt-d -b sqrt-d -b  )
	f+  			( F: a sqrt-d -b sqrt-d+-b  )
	f-rot           ( F: a sqrt-d+-b sqrt-d -b  )
	fswap f-        ( F: a sqrt-d+-b -b-sqrt-d  )
	frot 2e f*      ( F: sqrt-d+-b -b-sqrt-d 2a )
	fswap fover     ( F: sqrt-d+-b 2a -b-sqrt-d 2a )
	f/ f-rot        ( F: -b-sqrt-d/2a sqrt-d+-b 2a )
	f/              ( F: -b-sqrt-d/2a sqrt-d+-b/2a )
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

