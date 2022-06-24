«/
KC:\Mentoria\SMO.BackEnd\SMO.Backend\SMO.Business\Address\AddressBusiness.cs
	namespace 	
SMO
 
. 
Business 
. 
Address 
{ 
public		 

class		 
AddressBusiness		  
:		! "
IAddressBusiness		# 3
{

 
private 
readonly 
IAddressRepository +
AddressRepository, =
;= >
public 
AddressBusiness 
( 
IAddressRepository 1
addressRepository2 C
)C D
{ 	
AddressRepository 
= 
addressRepository  1
;1 2
} 	
public 
async 
Task 
< 
bool 
> 
CreateAddressUser  1
(1 2
AddressCreateModel2 D
addressCreateModelE W
,W X
intY \
idUser] c
)c d
{ 	
var 

addressDto 
= 
new  

AddressDto! +
(+ ,
addressCreateModel, >
)> ?
;? @
var 
addressUser 
= 
await #
GetAddressById$ 2
(2 3
idUser3 9
)9 :
;: ;
if 
( 
addressUser 
. 
Any 
(  
)  !
)! "
{ 
await 
UpdateFlagAddress '
(' (
idUser( .
). /
;/ 0
} 
return 
await 
AddressRepository *
.* +
CreateAddressUser+ <
(< =

addressDto= G
,G H
idUserI O
)O P
;P Q
} 	
public 
async 
Task 
< 
IEnumerable %
<% &

AddressDto& 0
>0 1
>1 2
GetAddressById3 A
(A B
intB E
idUserF L
)L M
{ 	
var   
addressUser   
=   
await   #
AddressRepository  $ 5
.  5 6
GetAddressById  6 D
(  D E
idUser  E K
)  K L
;  L M
return!! 
addressUser!! 
.!! 
Select!! %
(!!% &
address!!& -
=>!!. 0
new!!1 4

AddressDto!!5 ?
(!!? @
address!!@ G
)!!G H
)!!H I
;!!I J
}"" 	
public$$ 
async$$ 
Task$$ 
UpdateFlagAddress$$ +
($$+ ,
int$$, /
idUser$$0 6
)$$6 7
{%% 	
await&& 
AddressRepository&& #
.&&# $
UpdateFlagAddress&&$ 5
(&&5 6
idUser&&6 <
)&&< =
;&&= >
}'' 	
public)) 
async)) 
Task)) 
<)) 
bool)) 
>)) 
DeleteAddressUser))  1
())1 2
int))2 5
idUser))6 <
,))< =
int))> A
	idAddress))B K
)))K L
{** 	
var++ 
addressListUser++ 
=++  !
await++" '
AddressRepository++( 9
.++9 :%
GetAddressListOrderByDesc++: S
(++S T
idUser++T Z
)++Z [
;++[ \
var,, 
idsAddressEquals,,  
=,,! "

CompareIds,,# -
(,,- .
addressListUser,,. =
.,,= >
FirstOrDefault,,> L
(,,L M
),,M N
,,,N O
	idAddress,,P Y
),,Y Z
;,,Z [
if-- 
(-- 
idsAddressEquals--  
&&--! #
addressListUser--$ 3
.--3 4
Count--4 9
(--9 :
)--: ;
>=--< >
	Constants--? H
.--H I
TWO_ADDRESS--I T
)--T U
{.. 
await// 
AddressRepository// '
.//' ("
SetLatestFlagIdAddress//( >
(//> ?
addressListUser//? N
.//N O
	ElementAt//O X
(//X Y
	Constants//Y b
.//b c
SECOND_ADRRESS//c q
)//q r
)//r s
;//s t
}00 
return22 
await22 
AddressRepository22 *
.22* +
DeleteAddressUser22+ <
(22< =
	idAddress22= F
)22F G
;22G H
}33 	
public55 
async55 
Task55 
<55 
bool55 
>55 
UpdateAddress55  -
(55- .
AddressCreateModel55. @
addressModel55A M
,55M N
int55O R
	idAddress55S \
)55\ ]
{66 	
var77 

addressDto77 
=77 
new77 

AddressDto77  *
(77* +
addressModel77+ 7
)777 8
;778 9
return88 
await88 
AddressRepository88 )
.88) *
UpdateAddress88* 7
(887 8

addressDto888 B
,88B C
	idAddress88D M
)88M N
;88N O
}99 	
public;; 
async;; 
Task;; 
<;; 
bool;; 
>;;  
DeleteAllAddressUser;;  4
(;;4 5
int;;5 8
idUser;;9 ?
);;? @
{<< 	
return== 
await== 
AddressRepository== *
.==* + 
DeleteAllAddressUser==+ ?
(==? @
idUser==@ F
)==F G
;==G H
}>> 	
private@@ 
bool@@ 

CompareIds@@ 
(@@  
int@@  #
	idAddress@@$ -
,@@- .
int@@/ 2
idUserDelete@@3 ?
)@@? @
{AA 	
returnBB 
	idAddressBB 
.BB 
EqualsBB #
(BB# $
idUserDeleteBB$ 0
)BB0 1
;BB1 2
}CC 	
}DD 
}EE ·
GC:\Mentoria\SMO.BackEnd\SMO.Backend\SMO.Business\Login\LoginBusiness.cs
	namespace 	
SMO
 
. 
Business 
. 
Login 
{ 
public		 

class		 
LoginBusiness		 
:		  
ILoginBusiness		! /
{

 
private 
readonly 
IUserRepository (
UserRepository) 7
;7 8
private 
readonly 
IUserBusiness &
UsersBusiness' 4
;4 5
public 
LoginBusiness 
( 
IUserRepository ,
userRepository- ;
,; <
IUserBusiness= J
userBusinessK W
)W X
{ 	
UserRepository 
= 
userRepository +
;+ ,
UsersBusiness 
= 
userBusiness (
;( )
} 	
public 
async 
Task 
< 
UserDto !
>! "
	LoginUser# ,
(, -
	UserLogin- 6
	userLogin7 @
)@ A
{ 	
var 
idUser 
= 
await 
UserRepository -
.- .
ValidateUser. :
(: ;
	userLogin; D
)D E
;E F
return 
await 
UsersBusiness &
.& '
GetUserById' 2
(2 3
idUser3 9
)9 :
;: ;
} 	
} 
} ô@
EC:\Mentoria\SMO.BackEnd\SMO.Backend\SMO.Business\User\UserBusiness.cs
	namespace 	
SMO
 
. 
Business 
. 
User 
{ 
public 

class 
UserBusiness 
: 
IUserBusiness  -
{ 
private 
readonly 
IUserRepository (
UserRepository) 7
;7 8
private 
readonly 
IAddressBusiness )
AddressBusiness* 9
;9 :
public 
UserBusiness 
( 
IUserRepository +
userRepository, :
,: ;
IAddressBusiness< L
addressBusinessM \
)\ ]
{ 	
UserRepository 
= 
userRepository +
;+ ,
AddressBusiness 
= 
addressBusiness -
;- .
} 	
public 
async 
Task 
< 
bool 
> 

CreateUser  *
(* +
UserCreateModel+ :
	userModel; D
)D E
{ 	
var 
userDto 
= 
new 
UserDto %
(% &
	userModel& /
)/ 0
;0 1
using 
var 
transactionScope &
=' (
new) ,
TransactionScope- =
(= >+
TransactionScopeAsyncFlowOption> ]
.] ^
Enabled^ e
)e f
;f g
var 
	cpfExists 
= 
await !
UserRepository" 0
.0 1
GetUserByCpf1 =
(= >
	userModel> G
.G H
CPFH K
)K L
;L M
if 
( 
	cpfExists 
is 
not  
null! %
)% &
return 
false 
; 
var   
idUser   
=   
await   
UserRepository   -
.  - .

CreateUser  . 8
(  8 9
userDto  9 @
)  @ A
;  A B
var!! 
addressModel!! 
=!! 
CreateAddresModel!! 0
(!!0 1
	userModel!!1 :
)!!: ;
;!!; <
await"" 
AddressBusiness"" !
.""! "
CreateAddressUser""" 3
(""3 4
addressModel""4 @
,""@ A
idUser""B H
)""H I
;""I J
transactionScope## 
.## 
Complete## %
(##% &
)##& '
;##' (
return$$ 
true$$ 
;$$ 
}%% 	
public'' 
async'' 
Task'' 
<'' 
bool'' 
>'' 

UpdateUser''  *
(''* +
UserUpdateModel''+ :
	userModel''; D
,''D E
int''F I
idUser''J P
)''P Q
{(( 	
var)) 
userDto)) 
=)) 
new)) 
UserDto)) %
())% &
	userModel))& /
)))/ 0
;))0 1
return++ 
await++ 
UserRepository++ '
.++' (

UpdateUser++( 2
(++2 3
userDto++3 :
,++: ;
idUser++< B
)++B C
;++C D
},, 	
public.. 
async.. 
Task.. 
<.. 
UserDto.. !
>..! "
GetUserById..# .
(... /
int../ 2
id..3 5
)..5 6
{// 	
using00 
var00 
transactionScope00 &
=00' (
new00) ,
TransactionScope00- =
(00= >+
TransactionScopeAsyncFlowOption00> ]
.00] ^
Enabled00^ e
)00e f
;00f g
var11 

userEntity11 
=11 
await11 "
UserRepository11# 1
.111 2
GetUserById112 =
(11= >
id11> @
)11@ A
;11A B
var22 
addressUser22 
=22 
await22 #
AddressBusiness22$ 3
.223 4
GetAddressById224 B
(22B C
id22C E
)22E F
;22F G
transactionScope33 
.33 
Complete33 %
(33% &
)33& '
;33' (
var55 
mergeUserAddress55  
=55! "
MergeUserAddress55# 3
(553 4

userEntity554 >
,55> ?
addressUser55@ K
)55K L
;55L M
if77 
(77 
mergeUserAddress77  
is77! #
not77$ '
null77( ,
)77, -
{88 
return99 
mergeUserAddress99 '
;99' (
}:: 
return<< 
new<< 
UserDto<< 
(<< 
)<<  
;<<  !
}== 	
public?? 
async?? 
Task?? 
<?? 
bool?? 
>?? 
DeleteUserById??  .
(??. /
int??/ 2
idUser??3 9
)??9 :
{@@ 	
usingAA 
varAA 
transactionScopeAA &
=AA' (
newAA) ,
TransactionScopeAA- =
(AA= >+
TransactionScopeAsyncFlowOptionAA> ]
.AA] ^
EnabledAA^ e
)AAe f
;AAf g
varBB 
deleteAddressBB 
=BB 
awaitBB  %
AddressBusinessBB& 5
.BB5 6 
DeleteAllAddressUserBB6 J
(BBJ K
idUserBBK Q
)BBQ R
;BBR S
varCC 

deleteUserCC 
=CC 
awaitCC "
UserRepositoryCC# 1
.CC1 2
DeleteUserByIdCC2 @
(CC@ A
idUserCCA G
)CCG H
;CCH I
transactionScopeDD 
.DD 
CompleteDD %
(DD% &
)DD& '
;DD' (
returnEE 
deleteAddressEE  
&&EE! #

deleteUserEE$ .
;EE. /
}FF 	
privateII 
staticII 
UserDtoII 
MergeUserAddressII /
(II/ 0

UserEntityII0 :
?II: ;

userEntityII< F
,IIF G
IEnumerableIIH S
<IIS T

AddressDtoIIT ^
>II^ _
addressUserII` k
)IIk l
{JJ 	
ifKK 
(KK 

userEntityKK 
isKK 
notKK  
nullKK! %
)KK% &
{LL 
varMM 
userDtoMM 
=MM 
newMM !
UserDtoMM" )
(MM) *

userEntityMM* 4
)MM4 5
;MM5 6
ifNN 
(NN 
addressUserNN 
.NN  
AnyNN  #
(NN# $
)NN$ %
)NN% &
{OO 
userDtoPP 
.PP 
AddressDtosPP '
=PP( )
addressUserPP* 5
;PP5 6
}QQ 
returnSS 
userDtoSS 
;SS 
}TT 
returnVV 
newVV 
UserDtoVV 
(VV 
)VV  
;VV  !
}WW 	
privateYY 
staticYY 
AddressCreateModelYY )
CreateAddresModelYY* ;
(YY; <
UserCreateModelYY< K
	userModelYYL U
)YYU V
{ZZ 	
return[[ 
new[[ 
AddressCreateModel[[ )
([[) *
)[[* +
{\\ 
City]] 
=]] 
	userModel]]  
.]]  !
City]]! %
,]]% &
NumberHouse^^ 
=^^ 
	userModel^^ '
.^^' (
NumberHouse^^( 3
,^^3 4

PostalCode__ 
=__ 
	userModel__ &
.__& '

PostalCode__' 1
,__1 2
State`` 
=`` 
	userModel`` !
.``! "
State``" '
,``' (
Streetaa 
=aa 
	userModelaa "
.aa" #
Streetaa# )
,aa) *
Countrybb 
=bb 
	userModelbb #
.bb# $
Countrybb$ +
,bb+ ,

Complementcc 
=cc 
	userModelcc &
.cc& '

Complementcc' 1
}dd 
;dd 
}ee 	
}hh 
}ii 