(function($){

    function processForm( e ){
        var dict = {
			MovieId : this["movieId"].value,
        	Title : this["title"].value,
        	Director : this["director"].value,
			Genre : this["genre"].value
        };

        $.ajax({
            url: 'https://localhost:44352/api/movie',
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function( data, textStatus, jQxhr ){
                $('#response pre').html( data );
            },
            error: function( jqXhr, textStatus, errorThrown ){
                console.log( errorThrown );
            }
        });

        e.preventDefault();


        $('#my-form').submit( processForm );
    }

    function GetDetails(){
        $.ajax({
            url: 'https://localhost:44352/api/movie',
            dataType: 'json',
            type: 'get',
            contentType: 'application/json',
            success: function (data, textStatus, jQxhr) {
                $('#movieTable').html('');
                $.each(data, function (i) {
                    appendMovie(data[i]);
                });
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        });
    }

    



})(jQuery);

