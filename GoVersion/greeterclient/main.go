package main

import (
	"context"
	"github.com/yefuchao/greeter/greeter"
	"google.golang.org/grpc"
	"log"
	"os"
	"time"
)

const (
	address     = "localhost:50001"
	defaultName = "world"
)

func main(){
	conn,err := grpc.Dial(address,grpc.WithInsecure())

	if err != nil {
		log.Fatal(err)
	}

	defer conn.Close()

	c := greeter.NewGreeterClient(conn)

	name := defaultName

	if len(os.Args) > 1 {
		name = os.Args[1]
	}

	ctx ,cancle := context.WithTimeout(context.Background(),time.Second)

	defer cancle()

	r,err := c.SayHello(ctx,&greeter.HelloRequest{Name:name})

	if err != nil {
		log.Fatal(err)
	}

	log.Println(r.Message)
}