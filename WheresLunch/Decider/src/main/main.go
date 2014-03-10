package main

import(
"fmt"
"thrift"
"lunch"
)

func main(){
	
	transport,err := thrift.NewTSocket("localhost:9011")
	if err != nil{
		fmt.Println(err)
	}
	defer transport.Close()
	if err := transport.Open(); err != nil {
               fmt.Println(err)
    }
	client := lunch.NewLunchServiceClientFactory(transport,thrift.NewTCompactProtocolFactory())
	result, _ := client.MakeDecision();
	fmt.Printf("Eat at: %s!",result)
}