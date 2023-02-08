function Login() {}

Login.prototype.URL_LOGIN = "/Login/Acceder";

/**
 * Inicializa el componente
 */
Login.prototype.init = function() {
    this.txtEmail = $("#InputEmail");
    this.txtPassword = $("#InputPassword");
    this.btnLogin = $("#btnLogin");
    this.sectionError = $("#sectionError");

    this.btnLogin.click(this.onClickBtnLogin.bind(this));
}

Login.prototype.onClickBtnLogin = function() {
    this.cleanError();
    if (!this.validateData()) {
        return;
    }

    let params = {
        Correo: this.txtEmail.val(),
        Clave: this.txtPassword.val()
    }

    $.ajax({
        data: params,
        type: "POST",
        datatype: "json",
        url: this.URL_LOGIN,
        success: function(  result, textStatus, jqXHR  ) {
            if (result.error) {
                this.setError("Usuario y/o contraseña invalidas.");
                return;
            }
            sessionStorage.setItem("User",result.result);
            window.location.href = "/Home";
        }.bind(this)
    });
}

/**
 * valida si los datos ingresados son validos para llamar el controller
 * @returns {boolean}
 */
Login.prototype.validateData = function() {
    let regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (this.txtEmail.val() == "" || !regex.test(this.txtEmail.val())) {
        this.setError("El email ingresado no es valido");
        return false;
    }
    if (this.txtEmail.val() == ""){
        this.setError("La clave ingresada no es valida");
        return false;
    }
    return true;
}

Login.prototype.setError = function(mensaje) {
    this.sectionError.show();
    this.sectionError.empty();
    this.sectionError.append(mensaje);
}

Login.prototype.cleanError = function() {
    this.sectionError.hide();
    this.sectionError.empty();
}