package main

import (
	"fmt"
	"io/ioutil"
	"log"
	"net/http"
)

type Page struct {
	Title string
	Body []byte
}

func loadPage(title string) (*Page, error) {
	filename := title
	body,err := ioutil.ReadFile(filename)
	if err != nil {
		fmt.Println(err.Error())
		return nil,err
	}
	return &Page{Title:title, Body:body}, nil
}

func viewHandler(w http.ResponseWriter, r *http.Request) {
	title := r.URL.Path[len("/"):]
	fmt.Println("Title is", title)
	p,err := loadPage(title)
	if err != nil {
		fmt.Println(err.Error())
	}
	fmt.Fprintf(w, "%s", p.Body)
}

func main() {
	http.HandleFunc("/", viewHandler)
	log.Fatal(http.ListenAndServe(":8080",nil))
}