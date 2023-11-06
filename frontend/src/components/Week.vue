<template>
    <div class="week">
        <div v-for="(day, idx) in days" :key="idx">{{ day.getModel().toDateString() }}</div>
    </div>
</template>

<script lang="ts">
import { type DefineComponent } from 'vue'; // Import DefineComponent
import { DateWrapper } from '../models/DateWrapper';

export default {
    props: {
        days: {
            type: Array as () => DateWrapper[], // Use a type assertion for the array
            required: true,
            validator: (value: DateWrapper[]) => {
                return value.every((item) => item instanceof DateWrapper);
            },
        },
    },
} as DefineComponent<{
    days: DateWrapper[];
}>;
</script>

<style scoped>
.week {
    display: flex;
    justify-content: space-between;
}

</style>
