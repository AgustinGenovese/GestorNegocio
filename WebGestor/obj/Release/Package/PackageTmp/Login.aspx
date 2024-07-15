<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="WebGestor.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card mx-auto" style="max-width: 1000px; margin-top: 8%;">
        <div class="row g-0">
            <div class="col-md-4">
                <img src="https://www.tacticasoft.com/wp-content/uploads/2023/11/PERFIL-TACTICA111-300x300.png" class="card-img-top" alt="..." onerror="this.src='https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg'">
            </div>
            <div class="col-md-8 mb-3">
                <div class="card-body text-center">
                    <h2 class="card-title">TACTICASOFT</h2>
                    <p class="card-text">Establecemos alianzas estratégicas entre nuestros colaboradores y clientes a fin de lograr las mejores soluciones tecnológicas.</p>
                    <div class="mb-5 mt-3">
                        <a href="https://www.linkedin.com/company/tacticasoft/" target="_blank" rel="noopener">
                            <img src="https://www.tacticasoft.com/wp-content/uploads/2023/10/logo-linkedin.webp" width="45" alt="Linkedin - TACTICA"></a>
                        <a href="https://www.youtube.com/user/tacticasoft" target="_blank" rel="noopener">
                            <img src="https://www.tacticasoft.com/wp-content/uploads/2023/10/logo-youtube.webp" width="45" alt="YouTube - TACTICA"></a>
                        <a href="https://www.instagram.com/tacticasoft/" target="_blank" rel="noopener">
                            <img src="https://www.tacticasoft.com/wp-content/uploads/2023/11/logo-instagram.webp" width="45" alt="Instagram - TACTICA"></a>
                        <a href="https://www.facebook.com/Tacticasoft" target="_blank" rel="noopener">
                            <img src="https://www.tacticasoft.com/wp-content/uploads/2023/10/logo-facebook.webp" width="45" alt="Facebook - TACTICA"></a>
                        <a href="https://twitter.com/TACTICASOFT" target="_blank" rel="noopener">
                            <img src="https://www.tacticasoft.com/wp-content/uploads/2023/10/logo-x.webp" width="45" alt="X - TACTICA"></a>
                        <a href="https://www.tiktok.com/@tacticasoft" target="_blank" rel="noopener">
                            <img src="https://www.tacticasoft.com/wp-content/uploads/2023/10/logo-tiktok.webp" width="45" alt="Tik Tok - TACTICA"></a>
                    </div>
                    <div class="d-grid gap-2 col-6 mx-auto">
                        <asp:Button ID="IngresarButton" runat="server" CssClass="btn btn-primary" Text="Ingresar" OnClick="IngresarButton_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
