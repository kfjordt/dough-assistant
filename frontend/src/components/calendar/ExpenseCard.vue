<template>
    <div :style="{
        backgroundColor: expenseCardStyle.background,
        color: expenseCardStyle.text,
    }" class="z-10 text-xs rounded-md">
        <span class="expense-card-name">
            {{ props.name }}
        </span>
        <span class="expense-card-amount">
            {{ props.amount }}
        </span>
    </div>
</template>

<script setup lang="ts">
import { useStyleStore } from '../../stores/style';

const expenseCardStyle = useStyleStore().sectionStyles.calendar.expenseCards

const props = defineProps({
    amount: {
        type: Number,
        required: true
    },
    name: {
        type: String,
        required: true
    },
})

</script>