from django.db import models

# Create your models here.
class HighScore(models.Model):
    player = models.CharField(max_length=100)
    score = models.IntegerField()
    created = models.DateTimeField(auto_now_add=True)
    modified = models.DateTimeField(auto_now=True)

    def __str__(self):
        return self.player + ' : ' + str(self.score)