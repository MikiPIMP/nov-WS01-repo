<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="control_panel.aspx.cs" Inherits="WebShop.control_panel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="card">
                <div class="card-body">
                  <h4 class="card-title">Dodaj novi Artikal :</h4>
                  <p class="card-description">
                   Osnovne karakteristike
                  </p>
                 
                    <div class="form-group">
                      <label for="exampleInputName1">Naziv artikla:</label>
                     
                      <asp:TextBox ID="artikal_ime" runat="server" class="form-control"  placeholder="Ime" Height="50px"></asp:TextBox>
                    </div>
                    <div class="form-group">
                      <label for="exampleInputEmail3">Cena:</label>
                      <asp:TextBox ID="artikal_cena" runat="server" class="form-control"  placeholder="Cena" type="number" Height="50px"></asp:TextBox>
                    </div>
               
                    <div class="form-group">
                      <label for="exampleSelectGender">Status :</label>
                     <asp:DropDownList ID="artikal_vidljivo" runat="server" DataSourceID="SqlDataSource1" DataTextField="is_vidljivo" DataValueField="statusArtikla_id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:webshop1ConnectionString %>" SelectCommand="Pregled_Status" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                      </div>
                    <div class="form-group">
                      <label>Kategorija :</label>
                  <asp:DropDownList ID="artikal_kategorija" runat="server" DataSourceID="SqlDataSource2" DataTextField="kategorija_ime" DataValueField="kategorija_id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:webshop1ConnectionString %>" SelectCommand="Pregled_Kategorija" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                     
                    </div>
                    <div class="form-group">
                      <label for="exampleInputCity1">Opis:</label>
                       <asp:TextBox ID="artikal_opis" runat="server"  TextMode="MultiLine"  class="form-control"  rows="4" Height="100px"></asp:TextBox>
                    </div>
                    <div class="form-group">
                      <label for="exampleTextarea1">Kolicina:</label>
                      <asp:TextBox ID="artikal_kolicina" runat="server" class="form-control"  placeholder="Kolicina" type="number" Height="50px" OnTextChanged="artikal_kolicina_TextChanged"></asp:TextBox>
                    </div>
                   
                   <asp:Button ID="Button1" runat="server"  class="btn btn-primary me-2" Text="Dodaj slike" OnClick="Button1_Click" />
                  
                  
                </div>
              </div>

            
        
</asp:Content>
