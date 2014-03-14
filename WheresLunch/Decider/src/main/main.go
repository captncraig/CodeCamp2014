package main

import (
	"fmt"
	"lunch"
	"thrift"
)

func main() {
	transport, _ := thrift.NewTSocket("localhost:9011")

	defer transport.Close()
	transport.Open()

	client := lunch.NewLunchServiceClientFactory(transport, thrift.NewTCompactProtocolFactory())
	place, _ := client.MakeDecision()
	fmt.Printf("Eat at %s!\n", place)
}
