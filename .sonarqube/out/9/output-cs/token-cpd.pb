û
2C:\Mentoria\SMO.BackEnd\SMO.Backend\SMO.Map\Map.cs
	namespace 	
SMO
 
. 
Map 
{ 
public 

static 
class 
Map 
{ 
public 
static 
void $
SetupDependenceInjection 3
(3 4
IServiceCollection4 F
servicesG O
)O P
{ 	
services 
. 
	AddScoped 
< 
IUserBusiness ,
,, -
UserBusiness. :
>: ;
(; <
)< =
;= >
services 
. 
	AddScoped 
< 
IAddressBusiness /
,/ 0
AddressBusiness1 @
>@ A
(A B
)B C
;C D
services 
. 
	AddScoped 
< 
ILoginBusiness -
,- .
LoginBusiness/ <
>< =
(= >
)> ?
;? @
services 
. 
	AddScoped 
< 
	DbSession (
>( )
() *
)* +
;+ ,
services 
. 
	AddScoped 
< 
IUserRepository .
,. /
UserRepository0 >
>> ?
(? @
)@ A
;A B
services 
. 
	AddScoped 
< 
IAddressRepository 1
,1 2
AddressRepository3 D
>D E
(E F
)F G
;G H
}   	
}!! 
}"" 