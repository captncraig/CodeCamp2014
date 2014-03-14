thrift -gen csharp -out WheresLunchServer lunch.thrift
thrift -gen html:standalone lunch.thrift
thrift -gen js -out Web lunch.thrift

REM GOPATH set up to Decider directory
REM thrift library manually copied to thrift folder in there
thrift -gen go:thrift_import=thrift -out Decider\src lunch.thrift
go install lunch