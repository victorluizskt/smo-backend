÷è
OC:\Mentoria\SMO.BackEnd\SMO.Backend\SMO.Repository\Address\AddressRepository.cs
	namespace

 	
SMO


 
.

 

Repository

 
.

 
Address

  
{ 
public 

class 
AddressRepository "
:# $
IAddressRepository% 7
{ 
private 
readonly 
	DbSession "
userSession# .
;. /
public 
AddressRepository  
(  !
	DbSession! *
	dbSession+ 4
)4 5
{ 	
userSession 
= 
	dbSession #
;# $
} 	
private 
readonly 
string  
INSERT_ADDRESS_BY_ID  4
=5 6
DatabaseUtil7 C
.C D
LoadSqlStatementD T
(T U
$str #
,# $
typeof% +
(+ ,
AddressRepository, =
)= >
.> ?
	Namespace? H
) 	
;	 

private 
readonly 
string 
UPDATE_FLAG_USER  0
=1 2
DatabaseUtil3 ?
.? @
LoadSqlStatement@ P
(P Q
$str  
,  !
typeof" (
(( )
AddressRepository) :
): ;
.; <
	Namespace< E
) 	
;	 

private 
readonly 
string 
GET_ADDRESS_BY_ID  1
=2 3
DatabaseUtil4 @
.@ A
LoadSqlStatementA Q
(Q R
$str  
,  !
typeof" (
(( )
AddressRepository) :
): ;
.; <
	Namespace< E
) 	
;	 

private!! 
readonly!! 
string!! 
DELETE_ADDRESS_USER!!  3
=!!4 5
DatabaseUtil!!6 B
.!!B C
LoadSqlStatement!!C S
(!!S T
$str"" #
,""# $
typeof""% +
(""+ ,
AddressRepository"", =
)""= >
.""> ?
	Namespace""? H
)## 	
;##	 

private%% 
readonly%% 
string%% 
UPDATE_ADDRESS%%  .
=%%/ 0
DatabaseUtil%%1 =
.%%= >
LoadSqlStatement%%> N
(%%N O
$str&& 
,&&  
typeof&&! '
(&&' (
AddressRepository&&( 9
)&&9 :
.&&: ;
	Namespace&&; D
)'' 	
;''	 

private)) 
readonly)) 
string)) #
DELETE_ALL_ADDRESS_USER))  7
=))8 9
DatabaseUtil)): F
.))F G
LoadSqlStatement))G W
())W X
$str** &
,**& '
typeof**( .
(**. /
AddressRepository**/ @
)**@ A
.**A B
	Namespace**B K
)++ 	
;++	 

private-- 
readonly-- 
string-- !
GET_LATEST_ID_ADDRESS--  5
=--6 7
DatabaseUtil--8 D
.--D E
LoadSqlStatement--E U
(--U V
$str.. $
,..$ %
typeof..& ,
(.., -
AddressRepository..- >
)..> ?
...? @
	Namespace..@ I
)// 	
;//	 

private11 
readonly11 
string11 #
SET_LATEST_FLAG_ID_USER11  7
=118 9
DatabaseUtil11: F
.11F G
LoadSqlStatement11G W
(11W X
$str22 (
,22( )
typeof22* 0
(220 1
AddressRepository221 B
)22B C
.22C D
	Namespace22D M
)33 	
;33	 

public77 
async77 
Task77 
<77 
bool77 
>77 
CreateAddressUser77  1
(771 2

AddressDto772 <

addressDto77= G
,77G H
int77I L
idUser77M S
)77S T
{88 	
var99 
addressEntity99 
=99 
new99  #
AddressEntity99$ 1
(991 2

addressDto992 <
)99< =
;99= >
if;; 
(;; 
addressEntity;; 
is;; 
not;;  #
null;;$ (
);;( )
{<< 
using== 
var== 

connection== $
===% &
userSession==' 2
.==2 3
CreateConnection==3 C
(==C D
)==D E
;==E F
var?? 
dynamicParameters?? %
=??& '
new??( +
DynamicParameters??, =
(??= >
)??> ?
;??? @
dynamicParameters@@ !
.@@! "
Add@@" %
(@@% &
$str@@& 0
,@@0 1
idUser@@2 8
,@@8 9
DbType@@: @
.@@@ A
Int32@@A F
)@@F G
;@@G H
dynamicParametersAA !
.AA! "
AddAA" %
(AA% &
$strAA& /
,AA/ 0
addressEntityAA1 >
.AA> ?
StreetAA? E
,AAE F
DbTypeAAG M
.AAM N
StringAAN T
)AAT U
;AAU V
dynamicParametersBB !
.BB! "
AddBB" %
(BB% &
$strBB& -
,BB- .
addressEntityBB/ <
.BB< =
CityBB= A
,BBA B
DbTypeBBC I
.BBI J
StringBBJ P
)BBP Q
;BBQ R
dynamicParametersCC !
.CC! "
AddCC" %
(CC% &
$strCC& .
,CC. /
addressEntityCC0 =
.CC= >
StateCC> C
,CCC D
DbTypeCCE K
.CCK L
StringCCL R
)CCR S
;CCS T
dynamicParametersDD !
.DD! "
AddDD" %
(DD% &
$strDD& 3
,DD3 4
addressEntityDD5 B
.DDB C

PostalCodeDDC M
,DDM N
DbTypeDDO U
.DDU V
StringDDV \
)DD\ ]
;DD] ^
dynamicParametersEE !
.EE! "
AddEE" %
(EE% &
$strEE& 4
,EE4 5
addressEntityEE6 C
.EEC D
NumberHouseEED O
,EEO P
DbTypeEEQ W
.EEW X
StringEEX ^
)EE^ _
;EE_ `
dynamicParametersFF !
.FF! "
AddFF" %
(FF% &
$strFF& -
,FF- .
	ConstantsFF/ 8
.FF8 9
	FLAG_USERFF9 B
,FFB C
DbTypeFFD J
.FFJ K
Int32FFK P
)FFP Q
;FFQ R
dynamicParametersGG !
.GG! "
AddGG" %
(GG% &
$strGG& 0
,GG0 1
addressEntityGG2 ?
.GG? @
CountryGG@ G
,GGG H
DbTypeGGI O
.GGO P
StringGGP V
)GGV W
;GGW X
dynamicParametersHH !
.HH! "
AddHH" %
(HH% &
$strHH& 3
,HH3 4
addressEntityHH5 B
.HHB C

ComplementHHC M
,HHM N
DbTypeHHO U
.HHU V
StringHHV \
)HH\ ]
;HH] ^
dynamicParametersII !
.II! "
AddII" %
(II% &
$strII& :
,II: ;
DateTimeII< D
.IID E
NowIIE H
,IIH I
DbTypeIIJ P
.IIP Q
DateTimeIIQ Y
)IIY Z
;IIZ [
awaitKK 

connectionKK  
.KK  !
ExecuteAsyncKK! -
(KK- . 
INSERT_ADDRESS_BY_IDKK. B
,KKB C
dynamicParametersKKD U
)KKU V
;KKV W
returnLL 
trueLL 
;LL 
}MM 
returnOO 
falseOO 
;OO 
}PP 	
publicRR 
asyncRR 
TaskRR 
<RR 
IEnumerableRR %
<RR% &
AddressEntityRR& 3
>RR3 4
>RR4 5
GetAddressByIdRR6 D
(RRD E
intRRE H
idUserRRI O
)RRO P
{SS 	
usingTT 
varTT 

connectionTT  
=TT! "
userSessionTT# .
.TT. /
CreateConnectionTT/ ?
(TT? @
)TT@ A
;TTA B
varUU 
dynamicParametersUU !
=UU" #
newUU$ '
DynamicParametersUU( 9
(UU9 :
)UU: ;
;UU; <
dynamicParametersVV 
.VV 
AddVV !
(VV! "
$strVV" +
,VV+ ,
idUserVV- 3
,VV3 4
DbTypeVV5 ;
.VV; <
Int32VV< A
)VVA B
;VVB C
varXX 
addressModelsXX 
=XX 
awaitXX  %

connectionXX& 0
.XX0 1

QueryAsyncXX1 ;
<XX; <
AddressEntityXX< I
>XXI J
(XXJ K
GET_ADDRESS_BY_IDXXK \
,XX\ ]
dynamicParametersXX^ o
)XXo p
;XXp q
ifYY 
(YY 
addressModelsYY 
.YY 
AnyYY !
(YY! "
)YY" #
)YY# $
{ZZ 
return[[ 
addressModels[[ $
;[[$ %
}\\ 
return^^ 
new^^ 
List^^ 
<^^ 
AddressEntity^^ )
>^^) *
{^^+ ,
}^^- .
;^^. /
}__ 	
publicaa 
asyncaa 
Taskaa 
UpdateFlagAddressaa +
(aa+ ,
intaa, /
idUseraa0 6
)aa6 7
{bb 	
usingcc 
varcc 

connectioncc  
=cc! "
userSessioncc# .
.cc. /
CreateConnectioncc/ ?
(cc? @
)cc@ A
;ccA B
vardd 
dynamicParametersdd !
=dd" #
newdd$ '
DynamicParametersdd( 9
(dd9 :
)dd: ;
;dd; <
dynamicParametersee 
.ee 
Addee !
(ee! "
$stree" +
,ee+ ,
idUseree- 3
,ee3 4
DbTypeee5 ;
.ee; <
Int32ee< A
)eeA B
;eeB C
awaitff 

connectionff 
.ff 
ExecuteAsyncff )
(ff) *
UPDATE_FLAG_USERff* :
,ff: ;
dynamicParametersff< M
)ffM N
;ffN O
}gg 	
publicii 
asyncii 
Taskii 
<ii 
boolii 
>ii 
DeleteAddressUserii  1
(ii1 2
intii2 5
	idAddressii6 ?
)ii? @
{jj 	
usingll 
varll 

connectionll  
=ll! "
userSessionll# .
.ll. /
CreateConnectionll/ ?
(ll? @
)ll@ A
;llA B
varmm 
dynamicParametersmm !
=mm" #
newmm$ '
DynamicParametersmm( 9
(mm9 :
)mm: ;
;mm; <
dynamicParametersnn 
.nn 
Addnn !
(nn! "
$strnn" .
,nn. /
	idAddressnn0 9
,nn9 :
DbTypenn; A
.nnA B
Int32nnB G
)nnG H
;nnH I
awaitoo 

connectionoo 
.oo 
ExecuteAsyncoo )
(oo) *
DELETE_ADDRESS_USERoo* =
,oo= >
dynamicParametersoo? P
)ooP Q
;ooQ R
returnpp 
truepp 
;pp 
}qq 	
publicss 
asyncss 
Taskss 
<ss 
boolss 
>ss 
UpdateAddressss  -
(ss- .

AddressDtoss. 8

addressDtoss9 C
,ssC D
intssE H
	idAddressssI R
)ssR S
{tt 	
varuu 
addressEntityuu 
=uu 
newuu  #
AddressEntityuu$ 1
(uu1 2

addressDtouu2 <
)uu< =
;uu= >
usingvv 
varvv 

connectionvv  
=vv! "
userSessionvv# .
.vv. /
CreateConnectionvv/ ?
(vv? @
)vv@ A
;vvA B
varww 
dynamicParametersww !
=ww" #
newww$ '
DynamicParametersww( 9
(ww9 :
)ww: ;
;ww; <
dynamicParametersxx 
.xx 
Addxx !
(xx! "
$strxx" .
,xx. /
	idAddressxx0 9
,xx9 :
DbTypexx; A
.xxA B
Int32xxB G
)xxG H
;xxH I
dynamicParametersyy 
.yy 
Addyy !
(yy! "
$stryy" +
,yy+ ,
addressEntityyy- :
.yy: ;
Streetyy; A
,yyA B
DbTypeyyC I
.yyI J
StringyyJ P
)yyP Q
;yyQ R
dynamicParameterszz 
.zz 
Addzz !
(zz! "
$strzz" )
,zz) *
addressEntityzz+ 8
.zz8 9
Cityzz9 =
,zz= >
DbTypezz? E
.zzE F
StringzzF L
)zzL M
;zzM N
dynamicParameters{{ 
.{{ 
Add{{ !
({{! "
$str{{" *
,{{* +
addressEntity{{, 9
.{{9 :
State{{: ?
,{{? @
DbType{{A G
.{{G H
String{{H N
){{N O
;{{O P
dynamicParameters|| 
.|| 
Add|| !
(||! "
$str||" /
,||/ 0
addressEntity||1 >
.||> ?

PostalCode||? I
,||I J
DbType||K Q
.||Q R
String||R X
)||X Y
;||Y Z
dynamicParameters}} 
.}} 
Add}} !
(}}! "
$str}}" 0
,}}0 1
addressEntity}}2 ?
.}}? @
NumberHouse}}@ K
,}}K L
DbType}}M S
.}}S T
String}}T Z
)}}Z [
;}}[ \
dynamicParameters~~ 
.~~ 
Add~~ !
(~~! "
$str~~" )
,~~) *
$num~~+ ,
,~~, -
DbType~~. 4
.~~4 5
Int32~~5 :
)~~: ;
;~~; <
dynamicParameters 
. 
Add !
(! "
$str" ,
,, -
addressEntity. ;
.; <
Country< C
,C D
DbTypeE K
.K L
StringL R
)R S
;S T
dynamicParameters
ÄÄ 
.
ÄÄ 
Add
ÄÄ !
(
ÄÄ! "
$str
ÄÄ" /
,
ÄÄ/ 0
addressEntity
ÄÄ1 >
.
ÄÄ> ?

Complement
ÄÄ? I
,
ÄÄI J
DbType
ÄÄK Q
.
ÄÄQ R
String
ÄÄR X
)
ÄÄX Y
;
ÄÄY Z
await
ÇÇ 

connection
ÇÇ 
.
ÇÇ 
ExecuteAsync
ÇÇ )
(
ÇÇ) *
UPDATE_ADDRESS
ÇÇ* 8
,
ÇÇ8 9
dynamicParameters
ÇÇ: K
)
ÇÇK L
;
ÇÇL M
return
ÉÉ 
true
ÉÉ 
;
ÉÉ 
}
ÑÑ 	
public
ÜÜ 
async
ÜÜ 
Task
ÜÜ 
<
ÜÜ 
bool
ÜÜ 
>
ÜÜ "
DeleteAllAddressUser
ÜÜ  4
(
ÜÜ4 5
int
ÜÜ5 8
idUser
ÜÜ9 ?
)
ÜÜ? @
{
áá 	
using
àà 
var
àà 

connection
àà  
=
àà! "
userSession
àà# .
.
àà. /
CreateConnection
àà/ ?
(
àà? @
)
àà@ A
;
ààA B
var
ââ 
dynamicParameters
ââ !
=
ââ" #
new
ââ$ '
DynamicParameters
ââ( 9
(
ââ9 :
)
ââ: ;
;
ââ; <
dynamicParameters
ää 
.
ää 
Add
ää !
(
ää! "
$str
ää" +
,
ää+ ,
idUser
ää- 3
,
ää3 4
DbType
ää5 ;
.
ää; <
Int32
ää< A
)
ääA B
;
ääB C
await
ãã 

connection
ãã 
.
ãã 
ExecuteAsync
ãã )
(
ãã) *%
DELETE_ALL_ADDRESS_USER
ãã* A
,
ããA B
dynamicParameters
ããC T
)
ããT U
;
ããU V
return
åå 
true
åå 
;
åå 
}
çç 	
public
èè 
async
èè 
Task
èè 
<
èè 
IEnumerable
èè %
<
èè% &
int
èè& )
>
èè) *
>
èè* +'
GetAddressListOrderByDesc
èè, E
(
èèE F
int
èèF I
idUser
èèJ P
)
èèP Q
{
êê 	
using
ëë 
var
ëë 

connection
ëë  
=
ëë! "
userSession
ëë# .
.
ëë. /
CreateConnection
ëë/ ?
(
ëë? @
)
ëë@ A
;
ëëA B
var
íí 
dynamicParameters
íí !
=
íí" #
new
íí$ '
DynamicParameters
íí( 9
(
íí9 :
)
íí: ;
;
íí; <
dynamicParameters
ìì 
.
ìì 
Add
ìì !
(
ìì! "
$str
ìì" +
,
ìì+ ,
idUser
ìì- 3
,
ìì3 4
DbType
ìì5 ;
.
ìì; <
Int32
ìì< A
)
ììA B
;
ììB C
return
îî 
await
îî 

connection
îî #
.
îî# $

QueryAsync
îî$ .
<
îî. /
int
îî/ 2
>
îî2 3
(
îî3 4#
GET_LATEST_ID_ADDRESS
îî4 I
,
îîI J
dynamicParameters
îîK \
)
îî\ ]
;
îî] ^
}
ïï 	
public
óó 
async
óó 
Task
óó $
SetLatestFlagIdAddress
óó 0
(
óó0 1
int
óó1 4
	idAddress
óó5 >
)
óó> ?
{
òò 	
using
ôô 
var
ôô 

connection
ôô  
=
ôô! "
userSession
ôô# .
.
ôô. /
CreateConnection
ôô/ ?
(
ôô? @
)
ôô@ A
;
ôôA B
var
öö 
dynamicParameters
öö !
=
öö" #
new
öö$ '
DynamicParameters
öö( 9
(
öö9 :
)
öö: ;
;
öö; <
dynamicParameters
õõ 
.
õõ 
Add
õõ !
(
õõ! "
$str
õõ" .
,
õõ. /
	idAddress
õõ0 9
,
õõ9 :
DbType
õõ; A
.
õõA B
Int32
õõB G
)
õõG H
;
õõH I
await
úú 

connection
úú 
.
úú 
ExecuteAsync
úú )
(
úú) *%
SET_LATEST_FLAG_ID_USER
úú* A
,
úúA B
dynamicParameters
úúC T
)
úúT U
;
úúU V
}
ùù 	
}
ûû 
}üü ÿ
BC:\Mentoria\SMO.BackEnd\SMO.Backend\SMO.Repository\DatabaseUtil.cs
	namespace 	
SMO
 
. 

Repository 
. 
DatabaseUtils &
{ 
public 

class 
DatabaseUtil 
{ 
private 
const 
char 
PATH_SEPARATOR )
=* +
$char, /
;/ 0
public		 
static		 
string		 
LoadResourceFile		 -
(		- .
string		. 4
resourcePath		5 A
,		A B
string		C I
resourceName		J V
)		V W
{

 	
var 
executingAssembly !
=" #
typeof$ *
(* +
DatabaseUtil+ 7
)7 8
.8 9
Assembly9 A
;A B
var 
sqlStatement 
= 
string %
.% &
Empty& +
;+ ,
var 
pathBuilder 
= 
new !
StringBuilder" /
(/ 0
)0 1
;1 2
pathBuilder 
. 
Append 
( 
resourcePath +
)+ ,
;, -
pathBuilder 
. 
Append 
( 
PATH_SEPARATOR -
)- .
;. /
pathBuilder 
. 
Append 
( 
resourceName +
)+ ,
;, -
var 
sqlResourcePath 
=  !
pathBuilder" -
.- .
ToString. 6
(6 7
)7 8
;8 9
using 
var 
stream 
= 
executingAssembly 0
.0 1%
GetManifestResourceStream1 J
(J K
sqlResourcePathK Z
)Z [
;[ \
if 
( 
stream 
!= 
null 
) 
{ 
sqlStatement 
= 
new "
StreamReader# /
(/ 0
stream0 6
)6 7
.7 8
	ReadToEnd8 A
(A B
)B C
;C D
} 
return 
sqlStatement 
;  
} 	
public 
static 
string 
LoadSqlStatement -
(- .
string. 4
statementName5 B
,B C
stringD J
controllerNamespaceK ^
)^ _
{ 	
return   
DatabaseUtil   
.    
LoadResourceFile    0
(  0 1
string  1 7
.  7 8
Format  8 >
(  > ?
$str  ? J
,  J K
controllerNamespace  L _
??  ` b
string  c i
.  i j
Empty  j o
)  o p
,  p q
statementName  r 
)	   Ä
;
  Ä Å
}!! 	
}"" 
}## ‚l
IC:\Mentoria\SMO.BackEnd\SMO.Backend\SMO.Repository\User\UserRepository.cs
	namespace

 	
SMO


 
.

 

Repository

 
.

 
User

 
{ 
public 

class 
UserRepository 
:  !
IUserRepository" 1
{ 
private 
readonly 
	DbSession "
userSession# .
;. /
public 
UserRepository 
( 
	DbSession '
	dbSession( 1
)1 2
{ 	
userSession 
= 
	dbSession #
;# $
} 	
private 
static 
readonly 
string  &
INSERT_USER' 2
=3 4
DatabaseUtil5 A
.A B
LoadSqlStatementB R
(R S
$str 
, 
typeof $
($ %
UserRepository% 3
)3 4
.4 5
	Namespace5 >
) 	
;	 

private 
readonly 
string 
UPDATE_USER  +
=, -
DatabaseUtil. :
.: ;
LoadSqlStatement; K
(K L
$str 
, 
typeof $
($ %
UserRepository% 3
)3 4
.4 5
	Namespace5 >
) 	
;	 

private 
readonly 
string 
GET_USER_BY_ID  .
=/ 0
DatabaseUtil1 =
.= >
LoadSqlStatement> N
(N O
$str 
, 
typeof %
(% &
UserRepository& 4
)4 5
.5 6
	Namespace6 ?
) 	
;	 

private!! 
readonly!! 
string!! 
DELETE_USER!!  +
=!!, -
DatabaseUtil!!. :
.!!: ;
LoadSqlStatement!!; K
(!!K L
$str"" 
,"" 
typeof"" $
(""$ %
UserRepository""% 3
)""3 4
.""4 5
	Namespace""5 >
)## 	
;##	 

private%% 
readonly%% 
string%% 
VALIDATE_USER%%  -
=%%. /
DatabaseUtil%%0 <
.%%< =
LoadSqlStatement%%= M
(%%M N
$str&& #
,&&# $
typeof&&% +
(&&+ ,
UserRepository&&, :
)&&: ;
.&&; <
	Namespace&&< E
)'' 	
;''	 

private)) 
readonly)) 
string)) 
GET_USER_BY_CPF))  /
=))0 1
DatabaseUtil))2 >
.))> ?
LoadSqlStatement))? O
())O P
$str** 
,** 
typeof**  &
(**& '
UserRepository**' 5
)**5 6
.**6 7
	Namespace**7 @
)++ 	
;++	 

public.. 
async.. 
Task.. 
<.. 
int.. 
>.. 

CreateUser.. )
(..) *
UserDto..* 1
userDto..2 9
)..9 :
{// 	
var00 

userEntity00 
=00 
new00  

UserEntity00! +
(00+ ,
userDto00, 3
)003 4
;004 5
using22 
var22 

connection22  
=22! "
userSession22# .
.22. /
CreateConnection22/ ?
(22? @
)22@ A
;22A B
var33 
dynamicParameters33 !
=33" #
new33$ '
DynamicParameters33( 9
(339 :
)33: ;
;33; <
dynamicParameters44 
.44 
Add44 !
(44! "
$str44" )
,44) *

userEntity44+ 5
.445 6
Name446 :
,44: ;
DbType44< B
.44B C
String44C I
)44I J
;44J K
dynamicParameters55 
.55 
Add55 !
(55! "
$str55" *
,55* +

userEntity55, 6
.556 7
Email557 <
,55< =
DbType55> D
.55D E
String55E K
)55K L
;55L M
dynamicParameters66 
.66 
Add66 !
(66! "
$str66" -
,66- .

userEntity66/ 9
.669 :
Password66: B
,66B C
DbType66D J
.66J K
String66K Q
)66Q R
;66R S
dynamicParameters77 
.77 
Add77 !
(77! "
$str77" (
,77( )

userEntity77* 4
.774 5
CPF775 8
,778 9
DbType77: @
.77@ A
String77A G
)77G H
;77H I
dynamicParameters88 
.88 
Add88 !
(88! "
$str88" 0
,880 1

userEntity882 <
.88< =
NumberPhone88= H
,88H I
DbType88J P
.88P Q
String88Q W
)88W X
;88X Y
dynamicParameters99 
.99 
Add99 !
(99! "
$str99" 3
,993 4
DateTime995 =
.99= >
Now99> A
,99A B
DbType99C I
.99I J
DateTime99J R
)99R S
;99S T
var;; 
idUser;; 
=;; 
await;; 

connection;; )
.;;) *
QueryFirstAsync;;* 9
<;;9 :
int;;: =
>;;= >
(;;> ?
INSERT_USER;;? J
,;;J K
dynamicParameters;;L ]
);;] ^
;;;^ _
return<< 
idUser<< 
;<< 
}== 	
public?? 
async?? 
Task?? 
<?? 
bool?? 
>?? 

UpdateUser??  *
(??* +
UserDto??+ 2
userDto??3 :
,??: ;
int??< ?
idUser??@ F
)??F G
{@@ 	
varAA 

userEntityAA 
=AA 
newAA  

UserEntityAA! +
(AA+ ,
userDtoAA, 3
)AA3 4
;AA4 5
varBB 
userEditBB 
=BB 
awaitBB  
GetUserByIdBB! ,
(BB, -

userEntityBB- 7
.BB7 8
IdUserBB8 >
)BB> ?
;BB? @
ifCC 
(CC 
userEditCC 
isCC 
notCC 
nullCC #
)CC# $
{DD 
usingEE 
varEE 

connectionEE $
=EE% &
userSessionEE' 2
.EE2 3
CreateConnectionEE3 C
(EEC D
)EED E
;EEE F
varFF 
dynamicParametersFF %
=FF& '
newFF( +
DynamicParametersFF, =
(FF= >
)FF> ?
;FF? @
dynamicParametersGG !
.GG! "
AddGG" %
(GG% &
$strGG& /
,GG/ 0
idUserGG1 7
,GG7 8
DbTypeGG9 ?
.GG? @
Int32GG@ E
)GGE F
;GGF G
dynamicParametersHH !
.HH! "
AddHH" %
(HH% &
$strHH& -
,HH- .

userEntityHH/ 9
.HH9 :
NameHH: >
,HH> ?
DbTypeHH@ F
.HHF G
StringHHG M
)HHM N
;HHN O
dynamicParametersII !
.II! "
AddII" %
(II% &
$strII& .
,II. /

userEntityII0 :
.II: ;
EmailII; @
,II@ A
DbTypeIIB H
.IIH I
StringIII O
)IIO P
;IIP Q
dynamicParametersJJ !
.JJ! "
AddJJ" %
(JJ% &
$strJJ& 1
,JJ1 2

userEntityJJ3 =
.JJ= >
PasswordJJ> F
,JJF G
DbTypeJJH N
.JJN O
StringJJO U
)JJU V
;JJV W
dynamicParametersKK !
.KK! "
AddKK" %
(KK% &
$strKK& 4
,KK4 5

userEntityKK6 @
.KK@ A
NumberPhoneKKA L
,KKL M
DbTypeKKN T
.KKT U
StringKKU [
)KK[ \
;KK\ ]
awaitMM 

connectionMM  
.MM  !
ExecuteAsyncMM! -
(MM- .
UPDATE_USERMM. 9
,MM9 :
dynamicParametersMM; L
)MML M
;MMM N
returnNN 
trueNN 
;NN 
}OO 
returnQQ 
falseQQ 
;QQ 
}RR 	
publicTT 
asyncTT 
TaskTT 
<TT 

UserEntityTT $
>TT$ %
GetUserByIdTT& 1
(TT1 2
intTT2 5
idUserTT6 <
)TT< =
{UU 	
ifVV 
(VV 
idUserVV 
>VV 
$numVV 
)VV 
{WW 
usingXX 
varXX 

connectionXX $
=XX% &
userSessionXX' 2
.XX2 3
CreateConnectionXX3 C
(XXC D
)XXD E
;XXE F
varYY 
dynamicParametersYY %
=YY& '
newYY( +
DynamicParametersYY, =
(YY= >
)YY> ?
;YY? @
dynamicParametersZZ !
.ZZ! "
AddZZ" %
(ZZ% &
$strZZ& /
,ZZ/ 0
idUserZZ1 7
,ZZ7 8
DbTypeZZ9 ?
.ZZ? @
Int32ZZ@ E
)ZZE F
;ZZF G
var[[ 
	userModel[[ 
=[[ 
await[[  %

connection[[& 0
.[[0 1
QueryFirstAsync[[1 @
<[[@ A

UserEntity[[A K
>[[K L
([[L M
GET_USER_BY_ID[[M [
,[[[ \
dynamicParameters[[] n
)[[n o
;[[o p
return\\ 
	userModel\\  
;\\  !
}]] 
return__ 
new__ 

UserEntity__ !
(__! "
)__" #
;__# $
}`` 	
publicbb 
asyncbb 
Taskbb 
<bb 
boolbb 
>bb 
DeleteUserByIdbb  .
(bb. /
intbb/ 2
idbb3 5
)bb5 6
{cc 	
vardd 

userExistsdd 
=dd 
awaitdd "
GetUserByIddd# .
(dd. /
iddd/ 1
)dd1 2
;dd2 3
ifee 
(ee 

userExistsee 
isee 
notee !
nullee" &
)ee& '
{ff 
usinggg 
vargg 

connectiongg $
=gg% &
userSessiongg' 2
.gg2 3
CreateConnectiongg3 C
(ggC D
)ggD E
;ggE F
varhh 
dynamicParametershh %
=hh& '
newhh( +
DynamicParametershh, =
(hh= >
)hh> ?
;hh? @
dynamicParametersii !
.ii! "
Addii" %
(ii% &
$strii& /
,ii/ 0
idii1 3
,ii3 4
DbTypeii5 ;
.ii; <
Int32ii< A
)iiA B
;iiB C
awaitjj 

connectionjj  
.jj  !
ExecuteAsyncjj! -
(jj- .
DELETE_USERjj. 9
,jj9 :
dynamicParametersjj; L
)jjL M
;jjM N
returnll 
truell 
;ll 
}mm 
returnoo 
falseoo 
;oo 
}pp 	
publicrr 
asyncrr 
Taskrr 
<rr 
intrr 
>rr 
ValidateUserrr +
(rr+ ,
	UserLoginrr, 5
	userLoginrr6 ?
)rr? @
{ss 	
usingtt 
vartt 

connectiontt  
=tt! "
userSessiontt# .
.tt. /
CreateConnectiontt/ ?
(tt? @
)tt@ A
;ttA B
varuu 
dynamicParametersuu !
=uu" #
newuu$ '
DynamicParametersuu( 9
(uu9 :
)uu: ;
;uu; <
dynamicParametersvv 
.vv 
Addvv !
(vv! "
$strvv" /
,vv/ 0
	userLoginvv1 :
.vv: ;
Emailvv; @
,vv@ A
DbTypevvB H
.vvH I
StringvvI O
)vvO P
;vvP Q
dynamicParametersww 
.ww 
Addww !
(ww! "
$strww" 2
,ww2 3
	userLoginww4 =
.ww= >
Passwordww> F
,wwF G
DbTypewwH N
.wwN O
StringwwO U
)wwU V
;wwV W
varyy 
idUseryy 
=yy 
awaityy 

connectionyy )
.yy) *$
QueryFirstOrDefaultAsyncyy* B
<yyB C
intyyC F
>yyF G
(yyG H
VALIDATE_USERyyH U
,yyU V
dynamicParametersyyW h
)yyh i
;yyi j
return{{ 
idUser{{ 
;{{ 
}|| 	
public~~ 
async~~ 
Task~~ 
<~~ 
string~~  
>~~  !
GetUserByCpf~~" .
(~~. /
string~~/ 5
CpfUser~~6 =
)~~= >
{ 	
using
ÄÄ 
var
ÄÄ 

connection
ÄÄ  
=
ÄÄ! "
userSession
ÄÄ# .
.
ÄÄ. /
CreateConnection
ÄÄ/ ?
(
ÄÄ? @
)
ÄÄ@ A
;
ÄÄA B
var
ÅÅ 
dynamicParameters
ÅÅ !
=
ÅÅ" #
new
ÅÅ$ '
DynamicParameters
ÅÅ( 9
(
ÅÅ9 :
)
ÅÅ: ;
;
ÅÅ; <
dynamicParameters
ÇÇ 
.
ÇÇ 
Add
ÇÇ !
(
ÇÇ! "
$str
ÇÇ" (
,
ÇÇ( )
CpfUser
ÇÇ* 1
,
ÇÇ1 2
DbType
ÇÇ3 9
.
ÇÇ9 :
String
ÇÇ: @
)
ÇÇ@ A
;
ÇÇA B
return
ÉÉ 
await
ÉÉ 

connection
ÉÉ #
.
ÉÉ# $&
QueryFirstOrDefaultAsync
ÉÉ$ <
<
ÉÉ< =
string
ÉÉ= C
>
ÉÉC D
(
ÉÉD E
GET_USER_BY_CPF
ÉÉE T
,
ÉÉT U
dynamicParameters
ÉÉV g
)
ÉÉg h
;
ÉÉh i
}
ÑÑ 	
}
ÖÖ 
}ÜÜ 