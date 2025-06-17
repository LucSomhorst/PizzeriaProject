<?php
// database/seeders/IngredientSeeder.php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use App\Models\Ingredient;

class IngredientSeeder extends Seeder
{
    public function run(): void
    {
        Ingredient::factory()->count(30)->create();
    }
}

