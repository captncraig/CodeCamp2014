thrift -gen csharp -out WheresLunchServer lunch.thrift
thrift -gen html:standalone lunch.thrift
thrift -gen js lunch.thrift
thrift -gen go:thrift_import=thrift -out Decider\src lunch.thrift