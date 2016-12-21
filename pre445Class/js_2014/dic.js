amplitude_config = {}

function search() {
    var query_value = $('input#search').val();
	var category = $('#category option:selected').val();
	var difficulty = $('#difficulty option:selected').val();
	var show_atomic_only = $('#atomic input[type=radio]:checked').val();
	
    $('#search-string').html(query_value);
    if(query_value !== '' && /\S/.test(query_value)){
        $.ajax({
            type: "POST",
            url: "search.php",
            data: { query: query_value,
					category: category,
					difficulty: difficulty,
					atomic: show_atomic_only
			},
            cache: false,
			dataType: 'html',
            success: function(html){
			
				if(/\S/.test(html)) {$('#results').html(html);}
				else {$('#results').html('No results. Please try again.');}
				$('#results').fadeIn(200, function(){});
            }
        });
    }return false;
}

$(document).ready(function(){
$('input#submit').on('click', function(e) {
    clearTimeout($.data(this, 'timer'));
    var search_string = $('input#search').val();
        $('#results').fadeOut(200,function(){if (search_string == '') {
    
    }else{
       

        $(this).data('timer', setTimeout(search, 15));
    };});
	
	
});

$('#advance-search').on('click', function(e){
	e.preventDefault();
	$('#advance').toggle();
})

})