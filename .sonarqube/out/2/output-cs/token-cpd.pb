•
:C:\Mentoria\SMO.BackEnd\SMO.Backend\SMO.Utils\Constants.cs
	namespace 	
SMO
 
. 
Utils 
{ 
public 

static 
class 
	Constants !
{ 
public 
static 
int 
	FLAG_USER #
=$ %
$num& '
;' (
public 
static 
int 
TWO_ADDRESS %
=& '
$num( )
;) *
public 
static 
int 
SECOND_ADRRESS (
=) *
$num+ ,
;, -
} 
}		 Ø
?C:\Mentoria\SMO.BackEnd\SMO.Backend\SMO.Utils\Data\DbSession.cs
	namespace 	
SMO
 
. 
Utils 
. 
Data 
{ 
public 

class 
	DbSession 
: 
IDisposable (
{ 
private

 
string

 
_connectionString

 (
{

) *
get

+ .
;

. /
set

0 3
;

3 4
}

5 6
public 
IDbConnection 

Connection '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
IDbTransaction 
Transaction )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
	DbSession 
( 
IConfiguration '
configuration( 5
)5 6
{ 	
_connectionString 
= 
configuration! .
.. /
GetConnectionString/ B
(B C
$strC V
)V W
;W X
} 	
public 
void 
Dispose 
( 
) 
{ 	

Connection 
? 
. 
Close 
( 
) 
;  

Connection 
? 
. 
Dispose 
(  
)  !
;! "
} 	
public 
IDbConnection 
CreateConnection -
(- .
). /
{ 	

Connection 
= 
new 
SqlConnection *
(* +
_connectionString+ <
)< =
;= >
return 

Connection 
; 
} 	
} 
} ¼
KC:\Mentoria\SMO.BackEnd\SMO.Backend\SMO.Utils\Validations\ValidationUser.cs
	namespace 	
SMO
 
. 
Utils 
. 
Validations 
{ 
public 

static 
class 
ValidationUser &
{ 
public 
static 
bool 
ValidateUser '
(' (
UserCreateModel( 7
	userModel8 A
)A B
{ 	
if		 
(		 
!		 
string		 
.		 
IsNullOrWhiteSpace		 *
(		* +
	userModel		+ 4
.		4 5
Name		5 9
)		9 :
&&

 
!

 
string

 
.

 
IsNullOrWhiteSpace

 ,
(

, -
	userModel

- 6
.

6 7
Email

7 <
)

< =
&& 
! 
string 
. 
IsNullOrWhiteSpace ,
(, -
	userModel- 6
.6 7
CPF7 :
): ;
&& 
! 
string 
. 
IsNullOrWhiteSpace ,
(, -
	userModel- 6
.6 7
Password7 ?
)? @
&& 
! 
string 
. 
IsNullOrWhiteSpace ,
(, -
	userModel- 6
.6 7
NumberPhone7 B
)B C
)C D
returnE K
trueL P
;P Q
return 
false 
; 
} 	
} 
} 