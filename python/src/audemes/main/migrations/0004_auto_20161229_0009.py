# -*- coding: utf-8 -*-
# Generated by Django 1.10.4 on 2016-12-29 05:09
from __future__ import unicode_literals

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('main', '0003_auto_20161229_0005'),
    ]

    operations = [
        migrations.RenameModel(
            old_name='News',
            new_name='New',
        ),
    ]