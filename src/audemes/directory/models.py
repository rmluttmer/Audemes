from django.db import models

# Create your models here.
class Audeme(models.Model):
    name = models.CharField(max_length=50)
    file_location = models.CharField(max_length=1000)
    created = models.DateTimeField(auto_now_add=True)
    modified = models.DateTimeField(auto_now=True)

    def __str__(self):
        return self.name