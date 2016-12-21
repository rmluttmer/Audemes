var query_value;
var category;
var difficulty;
var show_atomic_only;
var categorylist = [
'All',
'Applied Science',
'Astology',
'Biology',
'Earth Science',
'Energy',
'General',
'Geology',
'Idiom',
'Physics'
]

function search() {
    console.log('query: '+ query_value);
    console.log('category: '+ category);
    console.log('difficulty: '+ difficulty);
    console.log('show_atomic_only: '+ show_atomic_only);
//    console.log('page_number: '+ page_number);

	
    $('#search-string').html(query_value);
    if(query_value !== '' && /\S/.test(query_value)){
        $.ajax({
            type: "POST",
            url: "search_new.php",
            data: { query: query_value,
					category: category,
					difficulty: difficulty,
					atomic: show_atomic_only,

			},
            cache: false,
			dataType: 'html',
            success: function(html){
			
				if(/\S/.test(html)) {
				$('#results').html(html);
				}
				else {$('#results').html('No results. Please try again.');}
				
				
            }
        });
    }
	return false;
}

$(document).ready(function(){
$('input#submit').on('click', function(e) {
    clearTimeout($.data(this, 'timer'));
    var search_string = $('input#search').val();
    
	
	if (search_string == '') {
        $('#results').fadeOut();
    //  $('#resultpanel').fadeOut();
	//$('.pagination').fadeOut();
		$('.categories').fadeIn();
    }else{
    //    $('#results').fadeIn();
    //    $('#resultpanel').fadeIn();
	//	$('.pagination').fadeIn();
	//	$('.categories').fadeOut();
	//	$('.category-link').fadeIn();
		query_value = $('input#search').val();
		category = $('#category option:selected').val();
		difficulty = $('#difficulty option:selected').val();
		show_atomic_only = $('#atomic input[type=radio]:checked').val();
        search();
    };
});

$('#advance-search').on('click', function(e){
	e.preventDefault();
	//$('#advance').toggle();
	$('#advance').animate({
					height: "toggle"}, 'fast');
					
					
})

$('.category').on('click', function(e){
	e.preventDefault();
    clearTimeout($.data(this, 'timer'));
	query_value = 'by_category';
	category = $(this).attr('data-category');
	//$('input#search').val('Category:'+categorylist[category]);
	//console.log(category);
	difficulty = $('#difficulty option:selected').val();
	show_atomic_only = $('#atomic input[type=radio]:checked').val();
	$(this).data('timer', setTimeout(search(1,1), 15));
	//$('.categories').fadeOut();
	$('#results').fadeIn();
	$('.pagination').fadeIn();
	$('.categories').fadeOut();
	$('.category-link').fadeIn();
	$('html,body').animate({
	scrollTop: $("body").offset().top},'fast');

})

})