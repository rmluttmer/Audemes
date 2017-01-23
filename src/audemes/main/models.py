from django.db import models

# Create your models here.
class New(models.Model):
    subject = models.CharField(max_length=100)
    author = models.CharField(max_length=100)
    body = models.CharField(max_length=1000)
    created = models.DateTimeField(auto_now_add=True)
    modified = models.DateTimeField(auto_now=True)

    def __str__(self):
        return self.author + ' : ' + self.subject
    
class GameAtomicAudeme(models.Model):
    question_text = models.CharField(max_length=200)
    pub_date = models.DateTimeField('date published')
        
    def __str__(self):
        return question_text


class GameComplexAudeme(models.Model):
    question = models.ForeignKey(GameAtomicAudeme, on_delete=models.CASCADE)
    choice_text = models.CharField(max_length=200)
    votes = models.IntegerField(default=0)  
    
    def __str__(self):
        return self.choice_text  
    
class Game(models.Model):
    question = models.ForeignKey(GameComplexAudeme, on_delete=models.CASCADE)
    choice_text = models.CharField(max_length=200)
    numAtomicAudemes = models.IntegerField(default=0)  
    
    def __str__(self):
        return self.choice_text     