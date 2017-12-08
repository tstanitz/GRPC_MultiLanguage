package main

import (
	"context"
	"log"

	pb "github.com/tstanitz/GRPC_MultiLanguage/GrpcDefinition"

	"google.golang.org/grpc"
)

const (
	address = "localhost:50050"
)

func main() {
	conn, err := grpc.Dial(address, grpc.WithInsecure())
	if err != nil {
		log.Fatalf("connection error %v", err)
	}

	defer conn.Close()

	c := pb.NewSalutationServerClient(conn)

	r, err := c.Salute(context.Background(), &pb.SampleRequest{Name: "GO"})
	if err != nil {
		log.Fatalf("could not connect: %v", err)
	}
	log.Printf(r.Salutation)
}
