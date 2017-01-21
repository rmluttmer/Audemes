from django.shortcuts import render
from django.http import HttpResponse


# Create your views here.

##def _layout(request):
  ##  return render(request, "main/templates/_layout.html", )

def home(request):
    return render(request, "main/index.html", )

def about(request):
    return render(request, "main/about.html", )

def game(request):
    return render(request, "main/game.html", )

def dictionary(request):
    return render(request, "main/dictionary.html", )