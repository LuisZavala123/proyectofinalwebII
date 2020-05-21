<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="proyectofinalwebII.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
   
    
    <header >
              <div class="carrucel">
                    <div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
                            <div class="carousel-inner">
                              <div class="carousel-item active">
                                    <div class="container">
                                            <div class="row d-flex h-100">
                                              <div class="col-sm-6 text-center justify-content-center align-self-center "">
                                                <h1>
                                                  Hamburguesa Bigman
                                                </h1>
                                                <p></p>
                                                <a href="#" class="btn btn-outline-secondary btn-lg text-white">
                                                  Read More
                                                </a>
                                              </div>
                                              <div class="col-sm-6">
                                                <img src="img/burger.png" class="img-fluid d-none d-sm-block">
                                              </div>
                                            </div>
                                          </div>
                              </div>
                              <div class="carousel-item">
                                    <div class="container">
                                            <div class="row d-flex h-100">
                                              <div class="col-sm-6 text-center justify-content-center align-self-center">
                                                <h1>
                                                  Pizza de peperoni
                                                </h1>
                                                <p>Ven y prueba nuestra pizza de peperoni</p>
                                                <a href="#" class="btn btn-outline-secondary btn-lg text-white">
                                                  Read More
                                                </a>
                                              </div>
                                              <div class="col-sm-6">
                                                <img src="img/pizza.png" class="img-fluid d-none d-sm-block">
                                              </div>
                                            </div>
                                          </div>
                              </div>
                              <div class="carousel-item">
                                    <div class="container">
                                            <div class="row d-flex h-100">
                                              <div class="col-sm-6 text-center justify-content-center align-self-center">
                                                <h1>
                                                  Alitas de pollo
                                                </h1>
                                                <p></p>
                                                <a href="#" class="btn btn-outline-secondary btn-lg text-white">
                                                  Read More
                                                </a>
                                              </div>
                                              <div class="col-sm-6">
                                                <img src="img/pollo.png" class="img-fluid d-none d-sm-block">
                                              </div>
                                            </div>
                                          </div>
                              </div>
                            </div>
                            <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
                              <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                              <span class="sr-only">Previous</span>
                            </a>
                            <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
                              <span class="carousel-control-next-icon" aria-hidden="true"></span>
                              <span class="sr-only">Next</span>
                            </a>
                          </div>
                        </div>
            </header>

            <!-- Noticias -->
            <section class="py-5">
            <div class="container">
              <div class="row">
                <div class="col-md-3">
                  <div class="card text-center carta-blanca">
                    <div class="card-body">
                      <h3>Noticia 1</h3>
                      <p>
                        
                      </p>
                    </div>
                  </div>
                </div>
                <div class="col-md-3">
                  <div class="card text-center carta-negra">
                    <div class="card-body">
                      <h3>Noticia 2</h3>
                      <p>
                         
                      </p>
                    </div>
                  </div>
                </div>
                <div class="col-md-3">
                  <div class="card text-center carta-blanca">
                    <div class="card-body">
                      <h3>Noticia 3</h3>
                      <p>
                        Amet alias a ipsa tempora ullam asperiores 
                      </p>
                    </div>
                  </div>
                </div>
                <div class="col-md-3">
                  <div class="card text-center carta-negra">
                    <div class="card-body">
                      <h3>Noticia 4</h3>
                      <p>
                        
                      </p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </section>
        
          <footer>
                <div class="container p-3">
                  <div class="row text-center text-white">
                    <div class="col ml-auto">
                            <p></p>
                    </div>
                  </div>
                </div>       
            </footer>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
