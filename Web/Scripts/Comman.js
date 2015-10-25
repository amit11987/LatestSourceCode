function validate() {
    //valid() not only tells us whether the form is valid but 
    //also ensures that errors are shown !!!
    if ($('form').valid()) {
        //if the form is valid we may need to hide previously displayed messages
        $(".validation-summary-errors").css("display", "none");
        $(".input-validation-error").removeClass("input-validation-error");
        return true;
    }
    else {
        //the form is not valide and because we are doing this all manually we also have to
        //show the validation summary manually 
        $(".validation-summary-errors").css("display", "block");
        return false;
    }
}

