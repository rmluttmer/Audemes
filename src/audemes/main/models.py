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